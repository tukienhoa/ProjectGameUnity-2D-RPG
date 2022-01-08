using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int playerMaxHealth;
    public int playerCurrentHealth;

    private bool flashActive;
    public float flashLength;
    private float flashCounter;

    private SFXManager sfxMan;

    private GameObject playerDeadDialog;

    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        sfxMan = FindObjectOfType<SFXManager>();
        playerDeadDialog = GameObject.Find("Canvas").transform.Find("PlayerDeadDialog").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
            sfxMan.playerDead.Play();
            playerDeadDialog.SetActive(true);
        }

    }

    IEnumerator HurtColor()
    {
        for (int i = 0; i < 3; i++)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.3f);
            yield return new WaitForSeconds(.1f);
            GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(.1f);
        }
    }

    public void HurtPlayer(int damageToGive)
    {
        playerCurrentHealth -= damageToGive;
        if (playerCurrentHealth < 0)
        {
            playerCurrentHealth = 0;
        }

        // Flash effect when player gets hit by enemy
        StartCoroutine("HurtColor");
        sfxMan.playerHurt.Play();
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    public int GetMaxHealth()
    {
        return playerMaxHealth;
    }

    public int GetCurrentHealth()
    {
        return playerCurrentHealth;
    }

    public void SetCurrentHealth(int value)
    {
        playerCurrentHealth = value;
    }

    public void ChangeMaxHealth(int healthValue)
    {
        playerMaxHealth += healthValue;

        // Handle when player unequips item -> decrease max health -> decrease current health if current health > new max health 
        if (playerMaxHealth < playerCurrentHealth)
            SetMaxHealth();
    }
}