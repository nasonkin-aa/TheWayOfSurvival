using System;
using UnityEngine;

public class Rage : MonoBehaviour, IWeaponModifier
{
    private static RageConfig _rageInfo;
    private static Weapon _weapon;

    private void Awake()
    {
        _weapon = Weapon.Inctance;
    }
    
    private void OnDisable()
    {
        Player.Instance.Health.ChangeEvent -= GetPowerForLostHp;
    }
    
    public void PrepareModifier(ModifierBaseObject rageInfo)
    {
        _rageInfo = rageInfo as RageConfig;
        Player.Instance.Health.ChangeEvent += GetPowerForLostHp;

        GetPowerForLostHp(0);
    }

    public void UpdateModifierInfo(ModifierBaseObject modifierConfig)
    {
        if (_rageInfo is null)
            return;
        _rageInfo = modifierConfig as RageConfig;
        GetPowerForLostHp(0);
    }
    
    private void GetPowerForLostHp(int delta)
    {
        var playerHealth = Player.Instance.Health;
        var lostHealth = _rageInfo.GetScale * (playerHealth.MaxHealth - playerHealth.CurrentHealth) / 5 ;
        lostHealth = MathF.Floor(lostHealth * 10) / 10;
        _weapon?.SetDamageWeapon(lostHealth);
        Debug.Log("+ damage" + (lostHealth ));
    }
}
