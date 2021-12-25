using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellInfoPanelController : MonoBehaviour
{
    public Text nameText;
    public Image frame;
    public Image image;
    public Text levelText;
    public Text MPCostText;
    public Text MPValue;
    public Text CDText;
    public Text CDValue;
    public Text detailsText;
    public Text descriptionText;

    // Start is called before the first frame update
    void Start()
    {
        SetActiveStatus(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetActiveStatus(bool status)
    {
        nameText.gameObject.SetActive(status);
        frame.gameObject.SetActive(status);
        image.gameObject.SetActive(status);
        levelText.gameObject.SetActive(status);
        MPCostText.gameObject.SetActive(status);
        MPValue.gameObject.SetActive(status);
        CDText.gameObject.SetActive(status);
        CDValue.gameObject.SetActive(status);
        detailsText.gameObject.SetActive(status);
        descriptionText.gameObject.SetActive(status);
    }
}
