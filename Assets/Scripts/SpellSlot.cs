using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellSlot : MonoBehaviour
{
    [SerializeField] GameObject spellObject;
    private Spell spell;

    [SerializeField] GameObject spellInfoPanel;
    private SpellInfoPanelController SIPController;

    [SerializeField] Text spellNameText;
    [SerializeField] Button spellButton;

    [SerializeField] Text spellLevelText;
    [SerializeField] Button upgradeButton;

    private SpellManager spellManager;

    private PlayerStats PS;


    // Start is called before the first frame update
    void Start()
    {
        spellManager = GameObject.Find("Player").GetComponent<SpellManager>();

        SIPController = spellInfoPanel.GetComponent<SpellInfoPanelController>();

        spell = spellObject.GetComponent<Spell>();
        spellNameText.text = spell.GetSpellName();
        spellButton.GetComponent<Image>().sprite = spell.spellSprite;

        PS = FindObjectOfType<PlayerStats>();

        switch (spell.GetSpellName())
        {
            case "Ice Shard":
                {
                    spellLevelText.text = spellManager.iceShardLevel + " / " + (spell.damageByLevel.Length - 1);
                    break;
                }
            case "Wind Breath":
                {
                    spellLevelText.text = spellManager.windBreathLevel + " / " + (spell.damageByLevel.Length - 1);
                    break;
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (spell.GetSpellName())
        {
            case "Ice Shard":
                {
                    if ((spellManager.iceShardLevel == spell.damageByLevel.Length - 1) || PS.GetSkillPoints() == 0)
                    {
                        upgradeButton.gameObject.SetActive(false);
                    }
                    else
                    {
                        upgradeButton.gameObject.SetActive(true);
                    }

                    spellLevelText.text = spellManager.iceShardLevel + " / " + (spell.damageByLevel.Length - 1);

                    break;
                }
            case "Wind Breath":
                {
                    if ((spellManager.windBreathLevel == spell.damageByLevel.Length - 1) || PS.GetSkillPoints() == 0)
                    {
                        upgradeButton.gameObject.SetActive(false);
                    }
                    else
                    {
                        upgradeButton.gameObject.SetActive(true);
                    }

                    spellLevelText.text = spellManager.windBreathLevel + " / " + (spell.damageByLevel.Length - 1);

                    break;
                }
        }


    }

    public void UpgradeSpell()
    {
        switch (spell.GetSpellName())
        {
            case "Ice Shard":
                {
                    if (spellManager.iceShardLevel < spell.damageByLevel.Length - 1)
                    {
                        spellManager.iceShardLevel++;
                        PS.ChangeSkillPoints(-1);
                        PS.ChangeUsedSkillPoints(1);

                        // Update level text
                        spellLevelText.text = spellManager.iceShardLevel + " / " + (spell.damageByLevel.Length - 1);

                        // Update spell info panel
                        SetSpellInfo();
                    }
                    break;
                }
            case "Wind Breath":
                {
                    if (spellManager.windBreathLevel < spell.damageByLevel.Length - 1)
                    {
                        spellManager.windBreathLevel++;
                        PS.ChangeSkillPoints(-1);
                        PS.ChangeUsedSkillPoints(1);

                        // Update level text
                        spellLevelText.text = spellManager.windBreathLevel + " / " + (spell.damageByLevel.Length - 1);

                        // Update spell info panel
                        SetSpellInfo();
                    }
                    break;
                }
        }
    }

    public void SetSpellInfo()
    {
        SIPController.nameText.text = spell.GetSpellName();
        SIPController.image.sprite = spell.spellSprite;

        switch (spell.GetSpellName())
        {
            case "Ice Shard":
                {
                    SIPController.descriptionText.text = "Cast an ice shard that deals " + spell.damageByLevel[spellManager.iceShardLevel] + " damage to an enemy.";
                    SIPController.levelText.text = spellManager.iceShardLevel + " / " + (spell.damageByLevel.Length - 1);
                    break;
                }
            case "Wind Breath":
                {
                    SIPController.descriptionText.text = "Make a wind slash that deals " + spell.damageByLevel[spellManager.windBreathLevel] + " damage to an enemy.";
                    SIPController.levelText.text = spellManager.windBreathLevel + " / " + (spell.damageByLevel.Length - 1);
                    break;
                }
        }

        SIPController.MPValue.text = "" + spell.MPCost;
        SIPController.CDValue.text = "" + spell.CD + " seconds";

        SIPController.SetActiveStatus(true);
    }
}
