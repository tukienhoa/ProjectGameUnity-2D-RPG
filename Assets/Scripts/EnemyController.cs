using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject thePlayer;
    private Rigidbody2D rb;
    public float moveSpeed = 4.0f;

    private Vector2 movement;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;

    public bool isWalking;
    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private int walkDirection;

    public Collider2D walkZone;
    private bool hasWalkZone;

    // Chasing
    public bool isChasing;

    // Animator
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = GameObject.Find("Player");

        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();

        if (walkZone != null)
        {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (isChasing)
        {
            Vector3 playerPosition = new Vector3(thePlayer.transform.position.x, thePlayer.transform.position.y, 0);
            Vector3 direction = playerPosition - transform.position;
            direction.Normalize();
            movement = direction;
            rb.velocity = direction;
            MoveCharacter(movement);
        }

        if (!isChasing)
        {
            if (isWalking)
            {
                walkCounter -= Time.deltaTime;

                switch (walkDirection)
                {
                    case 0:
                        rb.velocity = new Vector2(0, moveSpeed);
                        if (hasWalkZone && transform.position.y > maxWalkPoint.y)
                        {
                            isWalking = false;
                            waitCounter = waitTime;
                        }
                        break;
                    case 1:
                        rb.velocity = new Vector2(moveSpeed, 0);
                        if (hasWalkZone && transform.position.x > maxWalkPoint.x)
                        {
                            isWalking = false;
                            waitCounter = waitTime;
                        }
                        break;
                    case 2:
                        rb.velocity = new Vector2(0, -moveSpeed);
                        if (hasWalkZone && transform.position.y < minWalkPoint.y)
                        {
                            isWalking = false;
                            waitCounter = waitTime;
                        }

                        break;
                    case 3:
                        rb.velocity = new Vector2(-moveSpeed, 0);
                        if (hasWalkZone && transform.position.x < minWalkPoint.x)
                        {
                            isWalking = false;
                            waitCounter = waitTime;
                        }
                        break;
                }

                if (walkCounter <= 0)
                {
                    isWalking = false;
                    waitCounter = waitTime;
                }
            }
            else
            {
                waitCounter -= Time.deltaTime;

                rb.velocity = Vector2.zero;

                if (waitCounter <= 0)
                {
                    ChooseDirection();
                }
            }
        }

        anim.SetFloat("MoveX", rb.velocity.x);
        anim.SetFloat("MoveY", rb.velocity.y);
    }

    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime * 10));
    }

    public void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }
}
