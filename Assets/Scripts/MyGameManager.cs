using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager
{
    // Is new game
    public bool isNewGame = true;
    public bool isRunning = false;
    public bool areItemsLoaded = false;
    public bool isCoinLoaded = false;
    public bool areSpellsLoaded = false;

    // Singleton
    private static MyGameManager _instance;

    public static MyGameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MyGameManager();
            }
            return _instance;
        }
    }

    // Pause game
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    // Resume game
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    // Save game
    public void SaveGame(PlayerController playerController, PlayerStats playerStats, Inventory playerInventory,
                            GameObject itemsInventory, GameObject equipmentPanel)
    {
        // Save player's position
        PlayerPrefs.SetFloat("PosX", playerController.transform.position.x);
        PlayerPrefs.SetFloat("PosY", playerController.transform.position.y);
        PlayerPrefs.SetFloat("LastMoveX", playerController.lastMove.x);
        PlayerPrefs.SetFloat("LastMoveY", playerController.lastMove.y);

        // Save player's stats: Level, EXP, Status Points, current HP, current MP, Skill Points
        PlayerPrefs.SetInt("Level", playerStats.currentLevel);
        PlayerPrefs.SetInt("Exp", playerStats.currentExp);

        PlayerPrefs.SetInt("StatusPoints", playerStats.GetStatusPoints());
        PlayerPrefs.SetInt("ExtraHP", playerStats.GetExtraPoint("extraHP"));
        PlayerPrefs.SetInt("ExtraMP", playerStats.GetExtraPoint("extraMP"));
        PlayerPrefs.SetInt("ExtraATK", playerStats.GetExtraPoint("extraATK"));
        PlayerPrefs.SetInt("ExtraAP", playerStats.GetExtraPoint("extraAP"));
        PlayerPrefs.SetInt("ExtraDEF", playerStats.GetExtraPoint("extraDEF"));

        PlayerPrefs.SetInt("CurrentHP", playerStats.GetPlayerCurrentHealth());
        PlayerPrefs.SetInt("CurrentMP", playerStats.GetPlayerCurrentMP());

        PlayerPrefs.SetInt("SkillPoints", playerStats.GetSkillPoints());
        PlayerPrefs.SetInt("UsedSKillPoints", playerStats.GetUsedSkillPoints());

        // Save player's spells level
        PlayerPrefs.SetInt("IceShardLevel", playerStats.GetIceShardLevel());
        PlayerPrefs.SetInt("WindBreathLevel", playerStats.GetWindBreathLevel());

        // Save player's HP, MP potions, Coin
        PlayerPrefs.SetInt("HPPotion", playerInventory.GetHPPotionStock());
        PlayerPrefs.SetInt("MPPotion", playerInventory.GetMPPotionStock());
        PlayerPrefs.SetInt("Coin", playerInventory.GetCoin());

        // Save player's items in inventory
        // Delete old items in PlayerPrefs before saving
        if (PlayerPrefs.HasKey("ItemCount"))
        {
            int itemCount = PlayerPrefs.GetInt("ItemCount");
            for (int i = 0; i < itemCount; i++)
            {
                PlayerPrefs.DeleteKey("Item" + i);
            }
            PlayerPrefs.DeleteKey("ItemCount");
        }

        // Save
        List<Item> playerItems = itemsInventory.GetComponent<InventoryController>().GetItems();
        PlayerPrefs.SetInt("ItemCount", playerItems.Count);
        for (int i = 0; i < playerItems.Count; i++)
        {
            PlayerPrefs.SetString("Item" + i, playerItems[i].ItemName);
        }

        // Save player's equipped items in equipment panel
        EquipmentSlot[] equipmentSlots = equipmentPanel.GetComponent<EquipmentPanel>().GetEquipmentSlots();
        PlayerPrefs.SetInt("EquippedItemCount", equipmentSlots.Length);
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            PlayerPrefs.SetString("EquippedItem" + i, equipmentSlots[i].item == null ? "Empty" : equipmentSlots[i].item.ItemName);
        }
    }
}
