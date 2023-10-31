using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IAttackable
{
    protected List<ModifierPrepare> _modifiers = new ();
    public int WeaponDamage;
    public static Weapon GetWeapon { get; private set; }
    public virtual void Awake()
    {
        GetWeapon = this;
    }

    public abstract void Attack(Vector3 direction, Vector3 atackPoint);

    public void SetDamageWeapon(int value)
    {
        WeaponDamage = value;
    }
    

    public virtual void AddModifier(ModifierPrepare modifier)
    {
        _modifiers.Add(modifier);
    }
}
