using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] InventoryController inventory;
    [SerializeField] EquipmentPanel equipmentPanel;

    private PlayerStats thePS;

    private void Awake()
    {
        inventory.OnItemRightClickedEvent += EquipFromInventory;
        equipmentPanel.OnItemRightClickedEvent += UnequipFromPanel;
    }

    void Start()
    {
        thePS = FindObjectOfType<PlayerStats>();
        gameObject.SetActive(false);
    }

    private void EquipFromInventory(Item item)
    {
        if (item is EquippableItem)
        {
            Equip((EquippableItem)item);
        }
    }

    private void UnequipFromPanel(Item item)
    {
        if (item is EquippableItem)
        {
            Unequip((EquippableItem)item);
        }
    }

    public void Equip(EquippableItem item)
    {
        if (inventory.RemoveItem(item))
        {
            EquippableItem previousItem;
            if (equipmentPanel.AddItem(item, out previousItem))
            {
                if (previousItem != null)
                {
                    inventory.AddItem(previousItem);
                }

                // Update player's stats and UI
                item.Equip(thePS);
            }
            else
            {
                inventory.AddItem(item);
            }
        }
    }

    public void Unequip(EquippableItem item)
    {
        if (!inventory.IsFull() && equipmentPanel.RemoveItem(item))
        {
            inventory.AddItem(item);

            // Update player's stats and UI
            item.Unequip(thePS);
        }
    }
}
