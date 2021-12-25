using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public int[] damageByLevel;
    [SerializeField] string spellName;

    public Sprite spellSprite;

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

    private SpellManager spellManager;

    Animator anim;

    AudioSource audioSource;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        thePS = FindObjectOfType<PlayerStats>();
        anim = GetComponent<Animator>();
        playerMPManager = FindObjectOfType<PlayerMPManager>();
        spellManager = GameObject.Find("Player").GetComponent<SpellManager>();

        audioSource = GetComponent<AudioSource>();
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
            currentDamage = damageByLevel[spellManager.iceShardLevel] + thePS.currentAP;

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
        audioSource.Play();
        anim.SetFloat("MoveX", direction.x);
        anim.SetFloat("MoveY", direction.y);
        rb.AddForce(direction * force);
        playerMPManager.ConsumeMP(MPCost);
    }

    public string GetSpellName()
    {
        return spellName;
    }
}
