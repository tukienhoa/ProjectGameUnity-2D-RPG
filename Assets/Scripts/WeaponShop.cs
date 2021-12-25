using System.Collections;
using System.Collections.Generic;
using System.Text;
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
    public List<EquippableItem> items;

    private StringBuilder sb = new StringBuilder();

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
        for (int i = 0; i < items.Count; i++)
        {
            Weapon temp = new Weapon();
            temp.weaponName = items[i].ItemName;
            temp.weaponPrice = 20;
            temp.weaponSprite = items[i].Icon;
            temp.weaponID = weaponList.Count + 1;
            weaponList.Add(temp);
        }
        
        Debug.Log(weaponList.Count);
        
        for (int i = 0; i < weaponList.Count; i++)
        {
            GameObject holder = Instantiate(itemHolderPrefab, grid);
            holder.SetActive(true);
            ItemHolder holderScript = holder.GetComponent<ItemHolder>();

            holderScript.itemName.text = weaponList[i].weaponName;
            holderScript.itemPrice.text = weaponList[i].weaponPrice.ToString() + " G";
            holderScript.itemImage.sprite = weaponList[i].weaponSprite;
            holderScript.itemID = weaponList[i].weaponID;
            
            if (i == 0 || i == 1)
            {
                holderScript.itemStats.text = "";
            }
            else
            {
                sb.Length = 0;
                AddStat(items[i - 2].HPBonus, "HP");
                AddStat(items[i - 2].MPBonus, "MP");
                AddStat(items[i - 2].DEFBonus, "DEF");
                AddStat(items[i - 2].ATKBonus, "ATK");
                AddStat(items[i - 2].APBonus, "AP");
                holderScript.itemStats.text = sb.ToString();
            }
            
            // Buy button
            holderScript.buyButton.GetComponent<BuyButton>().weaponID =  weaponList[i].weaponID;

        }
    }

    void AddStat(int value, string statName)
    {
        if (value != 0)
        {
            if (sb.Length > 0)
                sb.AppendLine();

            if (value > 0)
                sb.Append("+");

            sb.Append(value);
            sb.Append(" ");
            sb.Append(statName);
        }
    }
}
