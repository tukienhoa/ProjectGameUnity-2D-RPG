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

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        thePS = FindObjectOfType<PlayerStats>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerMoving = false;

        if (!attacking && !isDashing)
        {
            // Move right / left
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                // transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed * Time.deltaTime, 0f));
                myRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, myRigidBody.velocity.y);
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
                lastVelocity = myRigidBody.velocity;
            }

            // Move up / down
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                // transform.Translate(new Vector2(0f, Input.GetAxisRaw("Vertical") * currentMoveSpeed * Time.deltaTime));
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
                lastVelocity = myRigidBody.velocity;
            }

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
}
