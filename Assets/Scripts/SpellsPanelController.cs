using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellsPanelController : MonoBehaviour
{
    [SerializeField] GameObject spellInfoPanel;
    [SerializeField] Text skillPointsText;
    [SerializeField] Button resetButton;

    private PlayerStats PS;
    private Inventory playerInventory;

    [SerializeField] QuestionDialog questionDialog;
    [SerializeField] QuestionDialog messageDialog;

    // Start is called before the first frame update
    void Start()
    {
        PS = FindObjectOfType<PlayerStats>();
        playerInventory = GameObject.Find("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        skillPointsText.text = "Skill Points: " + PS.GetSkillPoints();

        if (PS.GetUsedSkillPoints() == 0)
        {
            resetButton.gameObject.SetActive(false);
        }
        if (PS.GetUsedSkillPoints() != 0)
        {
            resetButton.gameObject.SetActive(true);
        }
    }

    public void OpenResetSkillsPointDialog()
    {
        questionDialog.gameObject.SetActive(true);
        questionDialog.text.text = "Spend 1000 coins to reset skill points?";
        questionDialog.OnYesEvent += ResetAllSkillPoints;
    }

    public void ResetAllSkillPoints()
    {
        if (playerInventory.GetCoin() < 1000)
        {
            messageDialog.text.text = "Not enough coins.";
            messageDialog.gameObject.SetActive(true);
        }
        else
        {
            spellInfoPanel.GetComponent<SpellInfoPanelController>().SetActiveStatus(false);
            playerInventory.ChangeCoinValue(-1000);
            PS.ResetSkillPoints();
        }
    }

}
