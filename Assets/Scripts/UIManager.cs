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

    // Start is called before the first frame update
    void Start()
    {
        // if (!UIExists)
        // {
        //     UIExists = true;
        //     DontDestroyOnLoad(transform.gameObject);
        // }
        // else
        // {
        //     Destroy(gameObject);
        // }

        thePS = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth;
        HPText.text = playerHealth.playerCurrentHealth + " / " + playerHealth.playerMaxHealth;
        levelText.text = "Level: " + thePS.currentLevel;
    }
}
