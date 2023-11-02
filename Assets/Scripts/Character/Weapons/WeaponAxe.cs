using System;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponAxe : RangeWeapon, IAttackable
{
    public override void Awake()
    {
        base.Awake();
        SetDamageWeapon(WeaponDamage);
        SelectRangeWeapon(WeaponType.Axe);
    }
}
