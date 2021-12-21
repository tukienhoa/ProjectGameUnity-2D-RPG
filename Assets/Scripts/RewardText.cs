using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RewardText : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI rewardTMP;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetText(string textToDisplay)
    {
        rewardTMP.text = textToDisplay;
    }
}
