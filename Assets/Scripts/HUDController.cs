using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HUDController : MonoBehaviour
{

    [SerializeField]
    private Text HPPotionStockText;
    [SerializeField]
    private Text MPPotionStockText;

    private Inventory playerInventory;

    private static bool HUDExists;

    // Start is called before the first frame update
    void Start()
    {
        if (!HUDExists)
        {
            HUDExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        playerInventory = FindObjectOfType<Inventory>();
        HPPotionStockText.text = "" + playerInventory.GetHPPotionStock();
        MPPotionStockText.text = "" + playerInventory.GetMPPotionStock();
    }

    // Update is called once per frame
    void Update()
    {
        HPPotionStockText.text = "" + playerInventory.GetHPPotionStock();
        MPPotionStockText.text = "" + playerInventory.GetMPPotionStock();
    }
}
