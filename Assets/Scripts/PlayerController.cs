using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Speed of the player
    public float moveSpeed;
    private float currentMoveSpeed;
    public float diagonalMoveModifier;

    private Animator anim;
    private Rigidbody2D myRigidBody;

    private bool playerMoving;
    public Vector2 lastMove;

    private static bool playerExists;

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    private bool isDashing;

    private PlayerStats thePS;

    private Vector2 lastVelocity;

    public bool canMove;

    public string startPoint;

    private SFXManager sfxMan;

    // Cast Spell
    private bool castingSpell;
    public float castSpellTime;
    private float castSpellTimeCounter;

    [SerializeField]
    private GameObject[] spellPrefabs;

    // Inventory
    public GameObject inventoryObj;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        thePS = FindObjectOfType<PlayerStats>();
        sfxMan = FindObjectOfType<SFXManager>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        canMove = true;
        lastMove = new Vector2(0, -1f);
    }

    // Update is called once per frame
    void Update()
    {
        playerMoving = false;

        if (!canMove)
        {
            myRigidBody.velocity = Vector2.zero;
            return;
        }

        if (!attacking && !isDashing && !castingSpell)
        {
            // Move right / left
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                myRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, myRigidBody.velocity.y);
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
                lastVelocity = myRigidBody.velocity;
            }

            // Move up / down
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
                lastVelocity = myRigidBody.velocity;
            }

            // Idle
            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
                myRigidBody.velocity = new Vector2(0f, myRigidBody.velocity.y);

            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0f);


            // Attack
            if (Input.GetKeyDown(KeyCode.Z))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                myRigidBody.velocity = Vector2.zero;
                anim.SetBool("Attack", true);

                sfxMan.playerAttack.Play();
            }

            // Diagonal moves
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
            {
                currentMoveSpeed = moveSpeed * diagonalMoveModifier;
            }
            else
            {
                currentMoveSpeed = moveSpeed;
            }

            // Dash
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isDashing = true;
                StartCoroutine("Dash");

            }

            // Open Chest
            if (Input.GetKeyDown(KeyCode.F))
            {
                RaycastHit2D hit = Physics2D.Raycast(myRigidBody.position + Vector2.up * 0.2f, lastVelocity.normalized, 1.5f, LayerMask.GetMask("Chest"));

                if (hit.collider != null)
                {
                    ChestController chest = hit.collider.GetComponent<ChestController>();
                    if (chest != null)
                    {
                        if (!chest.ChestOpened())
                        {
                            chest.Open();
                            thePS.AddExperience(chest.expReward);
                        }
                    }
                }
            }

            // Cast spell 1
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (GetComponent<PlayerMPManager>().playerCurrentMP >= spellPrefabs[0].GetComponent<Spell>().MPCost)
                {
                    castingSpell = true;
                    myRigidBody.velocity = Vector2.zero;
                    anim.SetBool("Spell", true);
                    CastSpell(0);
                    castSpellTimeCounter = castSpellTime;
                }
            }

            // Toggle Inventory
            if (Input.GetKeyDown(KeyCode.B))
            {
                inventoryObj.SetActive(!inventoryObj.activeSelf);
            }
        }

        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }
        if (attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("Attack", false);
        }

        if (castSpellTimeCounter > 0)
        {
            castSpellTimeCounter -= Time.deltaTime;
        }
        if (castSpellTimeCounter <= 0)
        {
            castingSpell = false;
            anim.SetBool("Spell", false);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }

    IEnumerator Dash()
    {
        for (int i = 0; i < 5; i++)
        {
            myRigidBody.AddForce(myRigidBody.velocity * 15);
            yield return new WaitForSeconds(0.05f);
        }
        isDashing = false;
    }

    public void CastSpell(int spellNumber)
    {
        GameObject spellObject = Instantiate(spellPrefabs[spellNumber], transform.position, Quaternion.identity);
        Spell spell = spellObject.GetComponent<Spell>();
        spell.Cast(lastVelocity, 50);
    }
}
