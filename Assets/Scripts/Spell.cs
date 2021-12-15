using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public int damageToGive;
    private int currentDamage;
    public GameObject damageBurst;
    public Transform hitPoint;

    public GameObject damageNumber;

    private PlayerStats thePS;
    private Rigidbody2D rb;

    public float duration;

    public int MPCost;
    public int CD;
    private PlayerMPManager playerMPManager;

    Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        thePS = FindObjectOfType<PlayerStats>();
        anim = GetComponent<Animator>();
        playerMPManager = FindObjectOfType<PlayerMPManager>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (duration > 0)
        {
            duration -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            currentDamage = damageToGive + thePS.currentAP;

            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(currentDamage);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);

            var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;

            duration = 0;
        }
        else if (other.gameObject.tag == "Object")
        {
            Destroy(gameObject);
        }
    }

    public void Cast(Vector2 direction, float force)
    {
        anim.SetFloat("MoveX", direction.x);
        anim.SetFloat("MoveY", direction.y);
        rb.AddForce(direction * force);
        playerMPManager.ConsumeMP(MPCost);
    }
}
