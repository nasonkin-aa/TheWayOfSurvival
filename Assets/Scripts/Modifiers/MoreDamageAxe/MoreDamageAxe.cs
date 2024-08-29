using UnityEngine;

public class MoreDamageAxe : MonoBehaviour, IWeaponModifier
{
    private static MoreDamageAxeConfig _moreDamageAxeInfo;
    private static Weapon _weapon;
    private void Awake()
    {
        _weapon = Weapon.Inctance;
    }
    public void PrepareModifier(ModifierBaseObject modifierConfig)
    {
        if (modifierConfig is MoreDamageAxeConfig axeConfig)
            _weapon.AddDamage((int)axeConfig.GetDamage);
    }

    public void UpdateModifierInfo(ModifierBaseObject modifierConfig)
    {
        if (_moreDamageAxeInfo is null)
            return;
        
        if (modifierConfig is MoreDamageAxeConfig axeConfig)
            _weapon.AddDamage((int)axeConfig.GetDamage);
    }
}
