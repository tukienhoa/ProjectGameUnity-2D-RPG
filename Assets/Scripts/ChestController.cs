using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public int expReward;

    private bool isOpened;


    Animator anim;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
    }

    public bool ChestOpened()
    {
        return isOpened;
    }
}
