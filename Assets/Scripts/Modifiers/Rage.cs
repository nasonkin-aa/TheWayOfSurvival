using UnityEngine;

public class Rage : MonoBehaviour, IWeaponModifier
{
    protected static RageConfig _rageInfo;
    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        Player.GetPlayer.GetHealth().OnHpChange -= GetPowerForLos�Hp;
    }
    void IWeaponModifier.PrepareModifier(ModifierBaseObject rageInfo)
    {
        _rageInfo = rageInfo as RageConfig;
        Player.GetPlayer.GetHealth().OnHpChange += GetPowerForLos�Hp;
    }

    private void GetPowerForLos�Hp(int healthChange)
    {
        var wepon = Weapon.GetWeapon;
        if (wepon is not null)
            wepon.WeaponDamage -= healthChange;
    }
}
