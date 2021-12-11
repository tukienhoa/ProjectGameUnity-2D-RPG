using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;

    private PlayerStats thePlayerStats;

    public int expToGive;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;

        thePlayerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            thePlayerStats.AddExperience(expToGive);

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
