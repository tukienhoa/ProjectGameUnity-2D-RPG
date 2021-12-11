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

    // Start is called before the first frame update
    void Start()
    {
        currentHP = HPLevels[1];
        currentMP = MPLevels[1];
        currentAttack = attackLevels[1];
        currentAP = APLevels[1];
        currentDefence = defenceLevels[1];

        thePlayerHealth = FindObjectOfType<PlayerHealthManager>();
        thePlayerMP = FindObjectOfType<PlayerMPManager>();
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
            currentHP = HPLevels[currentLevel];
            currentMP = MPLevels[currentLevel];
            currentExp -= toLevelUp[currentLevel - 1];

            thePlayerHealth.playerMaxHealth = currentHP;
            thePlayerHealth.playerCurrentHealth = currentHP;

            thePlayerMP.playerMaxMP = currentMP;
            thePlayerMP.playerCurrentMP = currentMP;

            currentAttack = attackLevels[currentLevel];
            currentAP = APLevels[currentLevel];
            currentDefence = defenceLevels[currentLevel];
        }
    }
}
