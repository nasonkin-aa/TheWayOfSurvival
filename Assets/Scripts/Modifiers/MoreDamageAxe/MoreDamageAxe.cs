using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreDamageAxe : MonoBehaviour, IWeaponModifier
{
    private static MoreDamageAxeConfig _moreDamageAxeInfo;
    private static Weapon _weapon;
    private void Awake()
    {
        _weapon = Weapon.GetWeapon;
    }
    public void PrepareModifier(ModifierBaseObject modifierConfig)
    {
        Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!11");
        var axeInfo = modifierConfig as MoreDamageAxeConfig;
        if (axeInfo != null) _weapon.AddDamage((int)axeInfo.GetDamage);
    }

    public void UpdateModifierInfo(ModifierBaseObject modifierConfig)
    {

        if (_moreDamageAxeInfo is null)
            return;
        var axeInfo = modifierConfig as MoreDamageAxeConfig;
        if (axeInfo != null) _weapon.AddDamage((int)axeInfo.GetDamage);
    }
}
