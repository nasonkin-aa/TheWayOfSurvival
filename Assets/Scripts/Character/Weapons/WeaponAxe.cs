using System;
using UnityEngine;

public class WeaponAxe : RangeWeapon, IAttackable
{
    private void Awake()
    {
        SelectRangeWeapon(WeaponType.Axe);
    }
}
