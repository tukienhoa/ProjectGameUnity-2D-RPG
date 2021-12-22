using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public Text textLevel;
    public Text textExp;
    public Text textHP;
    public Text textMP;
    public Text textDefence;
    public Text textAttack;
    public Text textAP;

    private PlayerStats PS;

    // Start is called before the first frame update
    void Start()
    {
        PS = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        textLevel.text = "Level " + PS.currentLevel;
        textExp.text = PS.currentExp + " / " + PS.toLevelUp[PS.currentLevel];
        textHP.text = "" + PS.GetPlayerMaxHealth();
        textMP.text = "" + PS.GetPlayerMaxMP();
        textDefence.text = "" + PS.currentDefence;
        textAttack.text = "" + PS.currentAttack;
        textAP.text = "" + PS.currentAP;
    }
}
