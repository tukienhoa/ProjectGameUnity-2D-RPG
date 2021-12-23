using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    private bool isOpened;

    Animator anim;

    AudioSource audioSource;

    BoxCollider2D boxCollider;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider2D>();

        isOpened = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Open()
    {
        isOpened = true;
        audioSource.Play();
        anim.SetTrigger("isOpened");
        boxCollider.enabled = false;
    }

    public bool DoorOpened()
    {
        return isOpened;
    }
}
