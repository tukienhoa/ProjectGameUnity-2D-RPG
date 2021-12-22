using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public int weaponID;

    private Inventory inventory;

    void Start() {
        inventory = FindObjectOfType<Inventory>();
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
                        inventory.ChangeCoinValue(-WeaponShop.weaponShop.weaponList[i].weaponPrice);
                        if (WeaponShop.weaponShop.weaponList[i].weaponID == 1)
                        {
                            inventory.SetHPPotionStock(inventory.GetHPPotionStock() + 1);
                        }
                        if (WeaponShop.weaponShop.weaponList[i].weaponID == 2)
                        {
                            inventory.SetMPPotionStock(inventory.GetMPPotionStock() + 1);
                        }
                    }
                }
            }
        }
        
    }
}
