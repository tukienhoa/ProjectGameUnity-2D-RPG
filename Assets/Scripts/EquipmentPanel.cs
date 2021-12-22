using System;
using UnityEngine;

public class EquipmentPanel : MonoBehaviour
{
    [SerializeField] Transform equipmentSlotsParent;
    [SerializeField] EquipmentSlot[] equipmentSlots;

    public event Action<Item> OnItemRightClickedEvent;

    private PlayerStats thePS;
    [SerializeField] DestroyItemDialog destroyItemDialog;

    public void Init()
    {
        thePS = FindObjectOfType<PlayerStats>();

        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            equipmentSlots[i].OnRightClickEvent += OnItemRightClickedEvent;
            equipmentSlots[i].OnLeftClickEvent += DeleteItem;
        }
    }

    private void OnValidate()
    {
        equipmentSlots = equipmentSlotsParent.GetComponentsInChildren<EquipmentSlot>();
    }

    public bool AddItem(EquippableItem item, out EquippableItem previousItem)
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].equipmentType == item.equipmentType)
            {
                previousItem = (EquippableItem)equipmentSlots[i].item;
                equipmentSlots[i].item = item;
                return true;
            }
        }
        previousItem = null;
        return false;
    }

    public bool RemoveItem(EquippableItem item)
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].item == item)
            {
                equipmentSlots[i].item = null;
                return true;
            }
        }

        return false;
    }

    private void DeleteItem(Item item)
    {
        destroyItemDialog.gameObject.SetActive(true);
        destroyItemDialog.OnYesEvent += () => DestroyItemInSlot(item);

    }

    private void DestroyItemInSlot(Item item)
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].item == item)
            {
                if (item is EquippableItem)
                {
                    EquippableItem equippableItem = (EquippableItem)item;
                    equippableItem.Unequip(thePS);
                    destroyItemDialog.gameObject.SetActive(false);
                }
                equipmentSlots[i].item = null;
            }
        }
    }
}
