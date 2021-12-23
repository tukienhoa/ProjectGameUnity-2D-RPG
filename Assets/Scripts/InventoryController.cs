using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] List<Item> items;
    [SerializeField] Transform itemsParent;
    [SerializeField] ItemSlot[] itemSlots;

    [SerializeField] QuestionDialog questionDialog;

    public event Action<Item> OnItemRightClickedEvent;

    public void Init()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].OnRightClickEvent += OnItemRightClickedEvent;
            itemSlots[i].OnLeftClickEvent += DeleteItem;
        }
    }

    private void OnValidate()
    {
        if (itemsParent != null)
        {
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
        }

        RefreshUI();
    }

    private void RefreshUI()
    {
        int i = 0;
        for (; i < items.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].item = items[i];
        }

        for (; i < itemSlots.Length; i++)
        {
            itemSlots[i].item = null;
        }
    }

    public bool IsFull()
    {
        return items.Count >= itemSlots.Length;
    }

    public bool AddItem(Item item)
    {
        if (IsFull())
        {
            return false;
        }

        items.Add(item);
        RefreshUI();
        return true;
    }

    public bool RemoveItem(Item item)
    {
        if (items.Remove(item))
        {
            RefreshUI();
            return true;
        }

        return false;
    }

    private void DeleteItem(Item item)
    {
        questionDialog.gameObject.SetActive(true);
        questionDialog.text.text = "Are you sure to destroy this item?";
        if (questionDialog.IsOnYesEventNull())
        {
            questionDialog.OnYesEvent += () => DestroyItemInSlot(item);
        }
    }

    private void DestroyItemInSlot(Item item)
    {
        items.Remove(item);
        RefreshUI();
        questionDialog.gameObject.SetActive(false);
    }
}
