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
        textHP.text = "" + PS.HPLevels[PS.currentLevel];
        textMP.text = "" + PS.MPLevels[PS.currentLevel];
        textDefence.text = "" + PS.defenceLevels[PS.currentLevel];
        textAttack.text = "" + PS.attackLevels[PS.currentLevel];
        textAP.text = "" + PS.APLevels[PS.currentLevel];
    }
}
