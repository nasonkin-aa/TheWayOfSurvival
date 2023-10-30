using System;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponAxe : RangeWeapon, IAttackable
{
    private void Awake()
    {
        SetDamageWeapon(WeaponDamage);
        SelectRangeWeapon(WeaponType.Axe);
    }
}
