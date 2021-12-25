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

    private SpellManager spellManager;


    // Start is called before the first frame update
    void Start()
    {
        spell = spellObject.GetComponent<Spell>();
        spellNameText.text = spell.GetSpellName();
        spellButton.GetComponent<Image>().sprite = spell.spellSprite;
        SIPController = spellInfoPanel.GetComponent<SpellInfoPanelController>();

        spellManager = GameObject.Find("Player").GetComponent<SpellManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpgradeSpell(string spellName)
    {
        switch (spellName)
        {
            case "Ice Shard":
                {
                    spellManager.iceShardLevel++;
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
                    SIPController.levelText.text = spellManager.iceShardLevel + " / " + spell.damageByLevel.Length;
                    break;
                }
        }

        SIPController.MPValue.text = "" + spell.MPCost;
        SIPController.CDValue.text = "" + spell.CD + " seconds";

        SIPController.SetActiveStatus(true);
    }
}
