using UnityEngine;

public class WeaponAxe : RangeWeapon, IAttackable
{
    public override void Awake()
    {
        base.Awake();
        var mod = new ElectricAOE();
        _modifiers.Add(mod);
    }
    public override void Attack(Vector3 direction, Vector3 atackPoint)
    {
        base.Attack(direction, atackPoint);
    }
}
