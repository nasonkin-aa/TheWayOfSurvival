using UnityEngine;

public class Rage : MonoBehaviour, IWeaponModifier
{
    protected static RageConfig _rageInfo;
    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        Player.GetPlayer.GetHealth().OnHpChange -= GetPowerForLosåHp;
    }
    void IWeaponModifier.PrepareModifier(ModifierBaseObject rageInfo)
    {
        _rageInfo = rageInfo as RageConfig;
        Player.GetPlayer.GetHealth().OnHpChange += GetPowerForLosåHp;
    }

    private void GetPowerForLosåHp(int healthChange)
    {
        var wepon = Weapon.GetWeapon;
        wepon?.SetDamageWeapon(wepon.WeaponDamage - (int)(healthChange * _rageInfo.GetScale)) ;
    }

    public void UpdateModifierInfo(ModifierBaseObject modifierConfig)
    {
        if (_rageInfo is null)
            return;

        _rageInfo = modifierConfig as RageConfig;
        var wepon = Weapon.GetWeapon;

        var playerHealth = Player.GetPlayer.GetHealth();
        var lostHealth = playerHealth.MaxHealth - playerHealth.Health;
        wepon?.SetDamageWeapon(wepon.BaseDamage + (int)(lostHealth * _rageInfo.GetScale));
    }
}
