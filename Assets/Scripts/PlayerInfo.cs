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

    public Text textSP;

    private PlayerStats PS;


    public GameObject buttons;
    public Button resetButton;

    [SerializeField] QuestionDialog questionDialog;
    [SerializeField] QuestionDialog messageDialog;

    private Inventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        PS = FindObjectOfType<PlayerStats>();
        playerInventory = FindObjectOfType<Inventory>();
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
        textSP.text = "STATUS POINTS: " + PS.GetStatusPoints();

        if (PS.GetStatusPoints() == 0)
        {
            buttons.SetActive(false);
        }
        if (PS.GetStatusPoints() != 0)
        {
            buttons.SetActive(true);
        }

        if (PS.IsNoStatusPointUsed())
        {
            resetButton.gameObject.SetActive(false);
        }
        if (!PS.IsNoStatusPointUsed())
        {
            resetButton.gameObject.SetActive(true);
        }
    }

    public void OpenResetStatusPointDialog()
    {
        questionDialog.gameObject.SetActive(true);
        questionDialog.text.text = "Spend 500 coins to reset status points?";
        questionDialog.OnYesEvent += ResetAllStatusPoints;
    }

    public void ResetAllStatusPoints()
    {
        if (playerInventory.GetCoin() < 500)
        {
            messageDialog.text.text = "Not enough coins.";
            messageDialog.gameObject.SetActive(true);
            questionDialog.gameObject.SetActive(false);
        }
        else
        {
            playerInventory.ChangeCoinValue(-500);
            PS.ResetStatusPoints();
            questionDialog.gameObject.SetActive(false);
        }
    }
}
