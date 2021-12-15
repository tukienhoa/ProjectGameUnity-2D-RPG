using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellCooldown : MonoBehaviour
{
    [SerializeField]
    private Image imageCooldown;
    [SerializeField]
    private TMP_Text textCooldown;

    [SerializeField]
    private GameObject spell;

    [SerializeField]
    private Text MPCostText;

    // Variables for cooldown timer
    private bool isCD = false;
    private float CDTime;
    private float CDTimer;

    // Start is called before the first frame update
    void Start()
    {
        textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0.0f;
        CDTime = spell.GetComponent<Spell>().CD;
        MPCostText.text = "" + spell.GetComponent<Spell>().MPCost;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCD)
        {
            ApplyCD();
        }
    }

    void ApplyCD()
    {
        CDTimer -= Time.deltaTime;

        if (CDTimer <= 0.0f)
        {
            isCD = false;
            textCooldown.gameObject.SetActive(false);
            imageCooldown.fillAmount = 0.0f;
        }
        else
        {
            textCooldown.text = Mathf.RoundToInt(CDTimer).ToString();
            imageCooldown.fillAmount = CDTimer / CDTime;
        }
    }

    public bool UseSpell()
    {
        if (isCD)
        {
            return false;
        }
        else
        {
            isCD = true;
            textCooldown.gameObject.SetActive(true);
            CDTimer = CDTime;
            return true;
        }
    }
}
