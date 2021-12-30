using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] InventoryController inventory;
    [SerializeField] EquipmentPanel equipmentPanel;

    private PlayerStats thePS;

    private static bool InventoryUIExists;

    private void Awake()
    {
        inventory.OnItemRightClickedEvent += EquipFromInventory;
        equipmentPanel.OnItemRightClickedEvent += UnequipFromPanel;
        inventory.Init();
        equipmentPanel.Init();
    }

    void Start()
    {
        if (!InventoryUIExists)
        {
            InventoryUIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        thePS = GameObject.Find("Canvas").GetComponent<PlayerStats>();

        // Load inventory items + equipment panel
        if (!MyGameManager.Instance.isNewGame)
        {
            // Load inventory items
            int itemCount = PlayerPrefs.GetInt("ItemCount");
            for (int i = 0; i < itemCount; i++)
            {
                string itemName = PlayerPrefs.GetString("Item" + i);
                string path = "";
                if (itemName.Contains("Sword"))
                {
                    path = "Items & Inventory/Equippable Items/Swords/" + itemName;
                }
                else if (itemName.Contains("Helmet"))
                {
                    path = "Items & Inventory/Equippable Items/Helmets/" + itemName;
                }
                else if (itemName.Contains("Armor"))
                {
                    path = "Items & Inventory/Equippable Items/Armors/" + itemName;
                }
                else if (itemName.Contains("Shoes"))
                {
                    path = "Items & Inventory/Equippable Items/Shoes/" + itemName;
                }

                Item item = Instantiate(Resources.Load(path)) as Item;
                inventory.AddItem(item);
            }

            // Load equipment panel
            int equippedItemCount = PlayerPrefs.GetInt("EquippedItemCount");
            for (int i = 0; i < equippedItemCount; i++)
            {
                string equippedItemName = PlayerPrefs.GetString("EquippedItem" + i);
                string path = "";
                if (equippedItemName.Contains("Sword"))
                {
                    path = "Items & Inventory/Equippable Items/Swords/" + equippedItemName;
                }
                else if (equippedItemName.Contains("Helmet"))
                {
                    path = "Items & Inventory/Equippable Items/Helmets/" + equippedItemName;
                }
                else if (equippedItemName.Contains("Armor"))
                {
                    path = "Items & Inventory/Equippable Items/Armors/" + equippedItemName;
                }
                else if (equippedItemName.Contains("Shoes"))
                {
                    path = "Items & Inventory/Equippable Items/Shoes/" + equippedItemName;
                }
                else
                {
                    path = null;
                }

                if (path != null)
                {
                    EquippableItem item = Instantiate(Resources.Load(path)) as EquippableItem;
                    EquippableItem prevItem;
                    if (equipmentPanel.AddItem(item, out prevItem))
                    {
                        // Update player's stats and UI
                        item.Equip(thePS);
                    }
                }
            }
        }

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
                    // Update player's stats and UI
                    previousItem.Unequip(thePS);
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
