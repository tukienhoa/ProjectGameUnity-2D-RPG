using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // HP + MP
    [SerializeField]
    private int HPPotionStock;
    [SerializeField]
    private int MPPotionStock;

    public GameObject healEffect;
    public GameObject manaEffect;

    private PlayerHealthManager playerHealthManager;
    private PlayerMPManager playerMPManager;

    // Coin
    [SerializeField]
    private int coin;

    // Start is called before the first frame update
    void Start()
    {
        playerHealthManager = GetComponent<PlayerHealthManager>();
        playerMPManager = GetComponent<PlayerMPManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UseHPPotion()
    {
        if (HPPotionStock > 0)
        {
            if (playerHealthManager.playerCurrentHealth < playerHealthManager.playerMaxHealth)
            {
                Instantiate(healEffect, transform.position, transform.rotation);

                if (playerHealthManager.playerCurrentHealth + 20 > playerHealthManager.playerMaxHealth)
                {
                    playerHealthManager.playerCurrentHealth = playerHealthManager.playerMaxHealth;
                }
                else
                {
                    playerHealthManager.playerCurrentHealth += 20;
                }

                HPPotionStock--;
            }
        }
    }

    public void UseMPPotion()
    {
        if (MPPotionStock > 0)
        {
            if (playerMPManager.playerCurrentMP < playerMPManager.playerMaxMP)
            {
                Instantiate(manaEffect, transform.position, transform.rotation);

                if (playerMPManager.playerCurrentMP + 10 > playerMPManager.playerMaxMP)
                {
                    playerMPManager.playerCurrentMP = playerMPManager.playerMaxMP;
                }
                else
                {
                    playerMPManager.playerCurrentMP += 10;
                }

                MPPotionStock--;
            }
        }
    }

    public int GetHPPotionStock()
    {
        return HPPotionStock;
    }

    public void SetHPPotionStock(int stock)
    {
        HPPotionStock = stock;
    }

    public int GetMPPotionStock()
    {
        return MPPotionStock;
    }

    public void SetMPPotionStock(int stock)
    {
        MPPotionStock = stock;
    }

    public void ChangeCoinValue(int value)
    {
        coin += value;
    }

    public int GetCoin()
    {
        return coin;
    }
}
