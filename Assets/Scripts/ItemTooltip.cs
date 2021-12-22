using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
    [SerializeField] Image itemImage;
    [SerializeField] Text itemNameText;
    [SerializeField] Text itemSlotText;
    [SerializeField] Text itemStatsText;

    void Start()
    {
        gameObject.SetActive(false);
    }

    private StringBuilder sb = new StringBuilder();

    public void ShowTooltip(EquippableItem item)
    {
        itemImage.sprite = item.Icon;
        itemSlotText.text = item.equipmentType.ToString();
        itemNameText.text = item.ItemName;

        sb.Length = 0;
        AddStat(item.HPBonus, "HP");
        AddStat(item.MPBonus, "MP");
        AddStat(item.DEFBonus, "DEF");
        AddStat(item.ATKBonus, "ATK");
        AddStat(item.APBonus, "AP");
        itemStatsText.text = sb.ToString();

        gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    private void AddStat(int value, string statName)
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
