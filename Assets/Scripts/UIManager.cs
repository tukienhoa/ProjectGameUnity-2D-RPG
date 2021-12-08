using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Text HPText;
    public PlayerHealthManager playerHealth;

    private PlayerStats thePS;
    public Text levelText;

    private static bool UIExists;

    // EXP bar
    public Slider expBar;
    public Text expText;

    // Start is called before the first frame update
    void Start()
    {
        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        playerHealth = FindObjectOfType<PlayerHealthManager>();
        thePS = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        // HP bar
        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth;
        HPText.text = playerHealth.playerCurrentHealth + " / " + playerHealth.playerMaxHealth;

        // EXP bar
        expBar.maxValue = thePS.toLevelUp[thePS.currentLevel];
        expBar.value = thePS.currentExp;
        expText.text = "EXP  " + expBar.value + " / " + expBar.maxValue;

        // Level
        levelText.text = "Level: " + thePS.currentLevel;
    }
}
