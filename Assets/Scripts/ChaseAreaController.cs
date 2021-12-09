using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAreaController : MonoBehaviour
{

    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            enemy.GetComponent<EnemyController>().isChasing = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            enemy.GetComponent<EnemyController>().isChasing = false;
        }
    }
}
