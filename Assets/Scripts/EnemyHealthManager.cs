using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;

    private PlayerStats thePlayerStats;
    private Inventory thePlayerInventory;


    [SerializeField]
    private int expToGive;
    [SerializeField]
    private int coinToGive;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;

        thePlayerStats = FindObjectOfType<PlayerStats>();
        thePlayerInventory = GameObject.Find("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            thePlayerStats.AddExperience(expToGive);
            thePlayerInventory.ChangeCoinValue(coinToGive);

            if (gameObject.GetComponent<EnemyController>() != null)
            {
                Destroy(transform.parent.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        CurrentHealth -= damageToGive;
        StartCoroutine("HurtColor");
    }

    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
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
}
