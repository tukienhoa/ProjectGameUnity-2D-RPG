using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    // HP bar
    public Slider healthBar;
    public Text HPText;
    private PlayerHealthManager playerHealth;

    // Player Level
    private PlayerStats thePS;
    public Text levelText;

    private static bool UIExists;

    // MP bar
    public Slider MPBar;
    public Text MPText;
    private PlayerMPManager playerMP;


    // EXP bar
    public Slider expBar;
    public Text expText;

    // Coin
    [SerializeField] TextMeshProUGUI coinTMP;
    private Inventory playerInventory;

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
        playerMP = FindObjectOfType<PlayerMPManager>();
        playerInventory = FindObjectOfType<Inventory>();
        thePS = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        // HP bar
        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth;
        HPText.text = playerHealth.playerCurrentHealth + " / " + playerHealth.playerMaxHealth;

        // MP bar
        MPBar.maxValue = playerMP.playerMaxMP;
        MPBar.value = playerMP.playerCurrentMP;
        MPText.text = playerMP.playerCurrentMP + " / " + playerMP.playerMaxMP;

        // EXP bar
        expBar.maxValue = thePS.toLevelUp[thePS.currentLevel];
        expBar.value = thePS.currentExp;
        expText.text = "EXP  " + expBar.value + " / " + expBar.maxValue;

        // Level
        levelText.text = "Level: " + thePS.currentLevel;

        // Coin
        coinTMP.text = "" + playerInventory.GetCoin();
    }
}
