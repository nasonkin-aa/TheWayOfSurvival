using UnityEngine;

public class Rage : MonoBehaviour, IWeaponModifier
{
    private static RageConfig _rageInfo;
    private static Weapon _weapon;

    private void Awake()
    {
        _weapon = Weapon.GetWeapon;
    }
    
    private void OnDisable()
    {
        Player.GetPlayer.GetHealth().OnHpChange -= GetPowerForLostHp;
    }
    public void PrepareModifier(ModifierBaseObject rageInfo)
    {
        _rageInfo = rageInfo as RageConfig;
        Player.GetPlayer.GetHealth().OnHpChange += GetPowerForLostHp;

        var playerHealth = Player.GetPlayer.GetHealth();
        var lostHealth = playerHealth.MaxHealth - playerHealth.Health;
        _weapon?.SetDamageWeapon(_weapon.WeaponDamage + (int)(lostHealth * _rageInfo.GetScale));
        Debug.Log("+ damage" + _weapon.WeaponDamage + (int)(lostHealth * _rageInfo.GetScale));
    }

    private void GetPowerForLostHp(int healthChange)
    {
        _weapon?.SetDamageWeapon(_weapon.WeaponDamage - (int)(healthChange * _rageInfo.GetScale)) ;
        Debug.Log("- damage" + (_weapon.WeaponDamage - (int)(healthChange * _rageInfo.GetScale)));
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
