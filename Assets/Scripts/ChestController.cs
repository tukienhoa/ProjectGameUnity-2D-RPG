using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] private int expReward;
    [SerializeField] private int coinReward;

    private bool isOpened;


    Animator anim;

    AudioSource audioSource;

    public GameObject dialogBox;
    public float displayTime = 1.5f;
    float timerDisplay;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        isOpened = false;

        dialogBox.SetActive(false);
        timerDisplay = -1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerDisplay > 0.0f)
        {
            timerDisplay -= Time.deltaTime;

            if (timerDisplay <= 0.0f)
            {
                dialogBox.SetActive(false);
            }
        }
    }


    public void Open()
    {
        isOpened = true;
        audioSource.Play();
        anim.SetTrigger("isOpened");

        if (coinReward == 0)
        {
            dialogBox.GetComponent<RewardText>().SetText("+ " + expReward + " EXP");
        }
        else if (expReward == 0)
        {
            dialogBox.GetComponent<RewardText>().SetText("+ " + coinReward + " COINS");
        }
        else
        {
            dialogBox.GetComponent<RewardText>().SetText("+ " + expReward + " EXP\n+ " + coinReward + " COINS");
        }

        timerDisplay = displayTime;
        dialogBox.SetActive(true);
    }

    public bool ChestOpened()
    {
        return isOpened;
    }

    public int GetExpReward()
    {
        return expReward;
    }

    public int GetCoinReward()
    {
        return coinReward;
    }
}
