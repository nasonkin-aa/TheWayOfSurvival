using UnityEngine;

public class Rage : MonoBehaviour, IWeaponModifier
{
    protected static RageConfig _rageInfo;
    protected static Weapon _weapon;

    private void Awake()
    {
        _weapon = Weapon.GetWeapon;
    }

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

        var playerHealth = Player.GetPlayer.GetHealth();
        var lostHealth = playerHealth.MaxHealth - playerHealth.Health;
        _weapon?.SetDamageWeapon(_weapon.BaseDamage + (int)(lostHealth * _rageInfo.GetScale));
    }

    private void GetPowerForLosåHp(int healthChange)
    {
        _weapon?.SetDamageWeapon(_weapon.WeaponDamage - (int)(healthChange * _rageInfo.GetScale));
    }

    public void UpdateModifierInfo(ModifierBaseObject modifierConfig)
    {
        if (_rageInfo is null)
            return;

        _rageInfo = modifierConfig as RageConfig;

        var playerHealth = Player.GetPlayer.GetHealth();
        var lostHealth = playerHealth.MaxHealth - playerHealth.Health;
        _weapon?.SetDamageWeapon(_weapon.BaseDamage + (int)(lostHealth * _rageInfo.GetScale));
    }
}
