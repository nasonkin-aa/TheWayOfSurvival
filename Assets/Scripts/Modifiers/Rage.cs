using UnityEngine;

public class Rage : MonoBehaviour, IWeaponModifier
{
    protected static RageConfig _rageInfo;
    protected static Weapon _weapon;

    private void Awake()
    {
        _weapon = Weapon.GetWeapon;
    }

    private void OnDisable()
    {
        Player.GetPlayer.GetHealth().ChangeEvent -= GetPowerForLost;
    }
    void IWeaponModifier.PrepareModifier(ModifierBaseObject rageInfo)
    {
        _rageInfo = rageInfo as RageConfig;
        Player.GetPlayer.GetHealth().ChangeEvent += GetPowerForLost;

        var playerHealth = Player.GetPlayer.GetHealth();
        var lostHealth = playerHealth.MaxHealth - playerHealth.CurrentHealth;
        _weapon?.SetDamageWeapon(_weapon.BaseDamage + (int)(lostHealth * _rageInfo.GetScale));
    }

    private void GetPowerForLost(int healthChange)
    {
        _weapon?.SetDamageWeapon(_weapon.WeaponDamage - (int)(healthChange * _rageInfo.GetScale));
    }

    public void UpdateModifierInfo(ModifierBaseObject modifierConfig)
    {
        if (_rageInfo is null)
            return;

        _rageInfo = modifierConfig as RageConfig;

        var playerHealth = Player.GetPlayer.GetHealth();
        var lostHealth = playerHealth.MaxHealth - playerHealth.CurrentHealth;
        _weapon?.SetDamageWeapon(_weapon.BaseDamage + (int)(lostHealth * _rageInfo.GetScale));
    }
}
