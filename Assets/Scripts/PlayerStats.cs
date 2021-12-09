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
    public int[] defenceLevels;

    public int currentHP;
    public int currentAttack;
    public int currentDefence;

    private PlayerHealthManager thePlayerHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = HPLevels[1];
        currentAttack = attackLevels[1];
        currentDefence = defenceLevels[1];

        thePlayerHealth = FindObjectOfType<PlayerHealthManager>();
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
            currentExp -= toLevelUp[currentLevel - 1];

            thePlayerHealth.playerMaxHealth = currentHP;
            thePlayerHealth.playerCurrentHealth = currentHP;

            currentAttack = attackLevels[currentLevel];
            currentDefence = defenceLevels[currentLevel];
        }
    }
}
