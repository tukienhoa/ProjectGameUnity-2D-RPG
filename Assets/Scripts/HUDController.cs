using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HUDController : MonoBehaviour
{
    private static bool HUDExists;

    public GameObject inventoryObj;

    [SerializeField]
    private Text HPPotionStockText;
    [SerializeField]
    private Text MPPotionStockText;

    private Inventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        playerInventory = FindObjectOfType<Inventory>();
        HPPotionStockText.text = "" + playerInventory.GetHPPotionStock();
        MPPotionStockText.text = "" + playerInventory.GetMPPotionStock();

        if (!HUDExists)
        {
            HUDExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        HPPotionStockText.text = "" + playerInventory.GetHPPotionStock();
        MPPotionStockText.text = "" + playerInventory.GetMPPotionStock();
    }

    public void ClickButton()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        if (name.Equals("InventoryBtn"))
        {
            inventoryObj.SetActive(!inventoryObj.activeSelf);
        }
    }
}
