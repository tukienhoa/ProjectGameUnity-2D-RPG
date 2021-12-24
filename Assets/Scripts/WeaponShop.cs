using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponShop : MonoBehaviour
{
    public static WeaponShop weaponShop;
    public List<Weapon> weaponList = new List<Weapon>();

    public GameObject itemHolderPrefab;
    public Transform grid;

    private Inventory inventory;

    public Text currencyNumber;

    // List items
    public List<Item> items;

    // Start is called before the first frame update
    void Start()
    {
        weaponShop = this;
        inventory = FindObjectOfType<Inventory>();
        FillList();
    }

    // Update is called once per frame
    void Update()
    {
        if (inventory != null)
        {
            currencyNumber.text = inventory.GetCoin().ToString();
        }
    }

    void FillList()
    {
        for (int i = 0; i < weaponList.Count; i++)
        {
            GameObject holder = Instantiate(itemHolderPrefab, grid);
            holder.SetActive(true);
            ItemHolder holderScript = holder.GetComponent<ItemHolder>();

            holderScript.itemName.text = weaponList[i].weaponName;
            holderScript.itemPrice.text = weaponList[i].weaponPrice.ToString() + " G";
            holderScript.itemImage.sprite = weaponList[i].weaponSprite;
            holderScript.itemID = weaponList[i].weaponID;

            // Buy button
            holderScript.buyButton.GetComponent<BuyButton>().weaponID =  weaponList[i].weaponID;

        }
    }
}
