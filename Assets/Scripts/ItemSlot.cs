using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image image;
    [SerializeField] ItemTooltip tooltip;

    public event Action<Item> OnRightClickEvent;

    private Item _item;
    public Item item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item == null)
            {
                image.enabled = false;
            }
            else
            {
                image.sprite = _item.Icon;
                image.enabled = true;
            }
        }
    }

    protected virtual void OnValidate()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }

        if (tooltip == null)
        {
            tooltip = FindObjectOfType<ItemTooltip>();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if (item != null && OnRightClickEvent != null)
            {
                OnRightClickEvent(item);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item is EquippableItem)
        {
            tooltip.ShowTooltip((EquippableItem)item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideTooltip();
    }
}
