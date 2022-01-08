using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public int weaponID;

    private Inventory inventory;

    private GameObject playerInventory;

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();

        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == "PlayerInventory")
                {
                    playerInventory = objs[i].gameObject;
                    break;
                }
            }
        }
    }

    public void BuyWeapon()
    {
        if (weaponID == 0)
        {
            Debug.Log("no weapon is set!");
            return;
        }

        for (int i = 0; i < WeaponShop.weaponShop.weaponList.Count; i++)
        {
            if (WeaponShop.weaponShop.weaponList[i].weaponID == weaponID)
            {
                if (inventory != null)
                {
                    if (inventory.GetCoin() >= WeaponShop.weaponShop.weaponList[i].weaponPrice)
                    {
                        if (WeaponShop.weaponShop.weaponList[i].weaponID == 1)
                        {
                            inventory.SetHPPotionStock(inventory.GetHPPotionStock() + 1);
                            inventory.ChangeCoinValue(-WeaponShop.weaponShop.weaponList[i].weaponPrice);
                        }

                        else if (WeaponShop.weaponShop.weaponList[i].weaponID == 2)
                        {
                            inventory.SetMPPotionStock(inventory.GetMPPotionStock() + 1);
                            inventory.ChangeCoinValue(-WeaponShop.weaponShop.weaponList[i].weaponPrice);
                        }

                        else
                        {
                            if (playerInventory != null)
                            {
                                if (!playerInventory.GetComponent<InventoryController>().IsFull())
                                {
                                    Item item = WeaponShop.weaponShop.items[weaponID - 3];
                                    playerInventory.GetComponent<InventoryController>().AddItem(item);
                                    inventory.ChangeCoinValue(-WeaponShop.weaponShop.weaponList[i].weaponPrice);
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
