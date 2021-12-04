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

    private SpriteRenderer playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = playerMaxHealth;

        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
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

        // Flash effect when player gets hit by enemy
        StartCoroutine("HurtColor");
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }
}