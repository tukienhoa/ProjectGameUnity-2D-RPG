using UnityEngine;

public enum EquipmentType
{
    Weapon,
    Armor
}

[CreateAssetMenu]
public class EquippableItem : Item
{
    public int HPBonus;
    public int MPBonus;
    public int DEFBonus;
    public int ATKBonus;
    public int APBonus;
    [Space]
    public EquipmentType equipmentType;

    public void Equip(PlayerStats thePS)
    {
        thePS.ChangePlayerMaxHealth(HPBonus);
        thePS.ChangePlayerMaxMP(MPBonus);
        thePS.currentDefence += DEFBonus;
        thePS.currentAttack += ATKBonus;
        thePS.currentAP += APBonus;
    }

    public void Unequip(PlayerStats thePS)
    {
        thePS.ChangePlayerMaxHealth(-HPBonus);
        thePS.ChangePlayerMaxMP(-MPBonus);
        thePS.currentDefence -= DEFBonus;
        thePS.currentAttack -= ATKBonus;
        thePS.currentAP -= APBonus;
    }
}
