using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardText : MonoBehaviour
{

    public Text rewardText;

    // Start is called before the first frame update
    void Start()
    {
        rewardText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetText(string textToDisplay)
    {
        rewardText.text = textToDisplay;
    }
}
