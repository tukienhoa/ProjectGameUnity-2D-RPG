using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Speed of the player
    public float moveSpeed;

    private Animator anim;

    private bool playerMoving;
    private Vector2 lastMove;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMoving = false;

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f));
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f);
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector2(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime));
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime);
        }

        anim.SetFloat("MoveX", Input.GetAxis("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}
