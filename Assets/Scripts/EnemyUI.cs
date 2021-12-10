using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    public Slider healthBar;
    public Text HPText;
    public GameObject enemy;

    private EnemyHealthManager enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = enemy.GetComponent<EnemyHealthManager>(); ;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = enemyHealth.CurrentHealth;
        healthBar.maxValue = enemyHealth.MaxHealth;
        HPText.text = "" + enemyHealth.CurrentHealth;
    }
}
