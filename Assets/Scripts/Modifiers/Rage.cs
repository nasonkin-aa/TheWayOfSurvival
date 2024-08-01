using System;
using System.Runtime.InteropServices;
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
        Player.GetPlayer.GetHealth().GetPowerRage -= GetPowerForLostHp;
    }
    public void PrepareModifier(ModifierBaseObject rageInfo)
    {
        _rageInfo = rageInfo as RageConfig;
        Player.GetPlayer.GetHealth().GetPowerRage += GetPowerForLostHp;

        GetPowerForLostHp();
    }

    public void UpdateModifierInfo(ModifierBaseObject modifierConfig)
    {
        if (_rageInfo is null)
            return;
        _rageInfo = modifierConfig as RageConfig;
        GetPowerForLostHp();
    }
    private void GetPowerForLostHp()
    {
        var playerHealth = Player.GetPlayer.GetHealth();
        var lostHealth = _rageInfo.GetScale * (playerHealth.MaxHealth - playerHealth.Health) / 5 ;
        lostHealth = MathF.Floor(lostHealth * 10) / 10;
        _weapon?.SetDamageWeapon((lostHealth ));
        Debug.Log("+ damage" + (lostHealth ));
    }

  

}
