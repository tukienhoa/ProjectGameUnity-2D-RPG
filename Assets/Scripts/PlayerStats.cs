using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentLevel;
    public int currentExp;

    public int[] toLevelUp;

    public int[] HPLevels;
    public int[] attackLevels;

    public int[] MPLevels;
    public int[] APLevels;
    public int[] defenceLevels;

    public int currentHP;
    public int currentAttack;
    public int currentMP;
    public int currentAP;
    public int currentDefence;

    private PlayerHealthManager thePlayerHealth;
    private PlayerMPManager thePlayerMP;

    // Manage Status Points
    private int statusPoints;
    private int extraHP;
    private int extraMP;
    private int extraDEF;
    private int extraATK;
    private int extraAP;

    // Manage Skill Points
    private int skillPoints;
    private int usedSkillPoints;

    private SpellManager spellManager;

    // Start is called before the first frame update
    void Start()
    {
        thePlayerHealth = FindObjectOfType<PlayerHealthManager>();
        thePlayerMP = FindObjectOfType<PlayerMPManager>();
        spellManager = GameObject.Find("Player").GetComponent<SpellManager>();

        if (MyGameManager.Instance.isNewGame)
        {
            currentHP = HPLevels[1];
            currentMP = MPLevels[1];
            currentAttack = attackLevels[1];
            currentAP = APLevels[1];
            currentDefence = defenceLevels[1];

            // Manage Status Points and extra points
            statusPoints = -1;
            extraHP = 0;
            extraMP = 0;
            extraDEF = 0;
            extraATK = 0;
            extraAP = 0;

            // Manage Skill Points
            skillPoints = -1;
            usedSkillPoints = 0;
        }
        else
        {
            // Load stats
            if (PlayerPrefs.HasKey("Level"))
            {
                currentLevel = PlayerPrefs.GetInt("Level");
                currentExp = PlayerPrefs.GetInt("Exp");

                statusPoints = PlayerPrefs.GetInt("StatusPoints");
                extraHP = PlayerPrefs.GetInt("ExtraHP");
                extraMP = PlayerPrefs.GetInt("ExtraMP");
                extraATK = PlayerPrefs.GetInt("ExtraATK");
                extraAP = PlayerPrefs.GetInt("ExtraAP");
                extraDEF = PlayerPrefs.GetInt("ExtraDEF");

                currentAttack = attackLevels[currentLevel] + extraATK;
                currentAP = APLevels[currentLevel] + extraAP;
                currentDefence = defenceLevels[currentLevel] + extraDEF;

                thePlayerHealth.playerMaxHealth = HPLevels[currentLevel] + extraHP;
                thePlayerMP.playerMaxMP = MPLevels[currentLevel] + extraMP;

                thePlayerHealth.playerCurrentHealth = PlayerPrefs.GetInt("CurrentHP");
                thePlayerMP.playerCurrentMP = PlayerPrefs.GetInt("CurrentMP");

                skillPoints = PlayerPrefs.GetInt("SkillPoints");
                usedSkillPoints = PlayerPrefs.GetInt("UsedSKillPoints");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentExp >= toLevelUp[currentLevel])
        {
            LevelUp();
        }
    }

    public void AddExperience(int experienceToAdd)
    {
        currentExp += experienceToAdd;
    }

    public void LevelUp()
    {
        if (currentLevel == toLevelUp.Length - 1)
        {
            currentExp = toLevelUp[currentLevel];
        }
        else
        {
            currentLevel++;
            currentHP = HPLevels[currentLevel] + extraHP;
            currentMP = MPLevels[currentLevel] + extraMP;
            currentExp -= toLevelUp[currentLevel - 1];

            thePlayerHealth.playerMaxHealth = currentHP;
            thePlayerHealth.playerCurrentHealth = currentHP;

            thePlayerMP.playerMaxMP = currentMP;
            thePlayerMP.playerCurrentMP = currentMP;

            currentAttack = attackLevels[currentLevel] + extraATK;
            currentAP = APLevels[currentLevel] + extraAP;
            currentDefence = defenceLevels[currentLevel] + extraDEF;

            statusPoints++;
            skillPoints++;
        }
    }



    public int GetPlayerMaxHealth()
    {
        return thePlayerHealth.GetMaxHealth();
    }

    public int GetPlayerCurrentHealth()
    {
        return thePlayerHealth.GetCurrentHealth();
    }

    public void ChangePlayerMaxHealth(int healthValue)
    {
        thePlayerHealth.ChangeMaxHealth(healthValue);
    }

    public int GetPlayerMaxMP()
    {
        return thePlayerMP.GetMaxMP();
    }

    public int GetPlayerCurrentMP()
    {
        return thePlayerMP.GetCurrentMP();
    }

    public void ChangePlayerMaxMP(int manaValue)
    {
        thePlayerMP.ChangeMaxMP(manaValue);
    }

    public int GetStatusPoints()
    {
        return statusPoints;
    }

    public int GetExtraPoint(string pointName)
    {
        switch (pointName)
        {
            case "extraHP":
                {
                    return extraHP;
                }
            case "extraMP":
                {
                    return extraMP;
                }
            case "extraATK":
                {
                    return extraATK;
                }
            case "extraAP":
                {
                    return extraAP;
                }
            case "extraDEF":
                {
                    return extraDEF;
                }
        }

        return 0;
    }

    public void UseStatusPoints(string statToIncrease)
    {
        if (statusPoints != 0)
        {
            switch (statToIncrease)
            {
                case "HP":
                    {
                        extraHP++;
                        thePlayerHealth.ChangeMaxHealth(1);
                        statusPoints--;
                        break;
                    }
                case "MP":
                    {
                        extraMP++;
                        thePlayerMP.ChangeMaxMP(1);
                        statusPoints--;
                        break;
                    }
                case "DEF":
                    {
                        extraDEF++;
                        currentDefence++;
                        statusPoints--;
                        break;
                    }
                case "ATK":
                    {
                        extraATK++;
                        currentAttack++;
                        statusPoints--;
                        break;
                    }
                case "AP":
                    {
                        extraAP++;
                        currentAP++;
                        statusPoints--;
                        break;
                    }
            }
        }
    }

    public bool IsNoStatusPointUsed()
    {
        return extraHP == 0 && extraMP == 0 && extraDEF == 0 && extraATK == 0 && extraAP == 0;
    }

    public void ResetStatusPoints()
    {
        thePlayerHealth.ChangeMaxHealth(-extraHP);
        thePlayerMP.ChangeMaxMP(-extraMP);
        currentDefence -= extraDEF;
        currentAttack -= extraATK;
        currentAP -= extraAP;

        extraHP = 0;
        extraMP = 0;
        extraDEF = 0;
        extraATK = 0;
        extraAP = 0;

        statusPoints = currentLevel - 1;
    }

    // Manage Skill Points
    public void ChangeSkillPoints(int value)
    {
        skillPoints += value;
    }

    public int GetSkillPoints()
    {
        return skillPoints;
    }

    public void ChangeUsedSkillPoints(int value)
    {
        usedSkillPoints += value;
    }

    public int GetUsedSkillPoints()
    {
        return usedSkillPoints;
    }

    public void ResetSkillPoints()
    {
        // Reset spells' level
        spellManager.iceShardLevel = 1;
        spellManager.windBreathLevel = 1;

        // Reset skill points
        skillPoints += usedSkillPoints;
        usedSkillPoints = 0;
    }

    public int GetIceShardLevel()
    {
        return spellManager.iceShardLevel;
    }

    public int GetWindBreathLevel()
    {
        return spellManager.windBreathLevel;
    }
}
