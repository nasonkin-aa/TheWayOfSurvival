using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IAttackable
{
    protected List<ModifierPrepare> _modifiers = new ();
    [field: SerializeField, Range(0, 1000)] public int BaseDamage { get; protected set; } = 10;
    [field: SerializeField, Range(0, 1000)] public int WeaponDamage { get; protected set; } = 10;
    [field: SerializeField, Range(0, 1000)] public int MoreDamage { get; private set; } = 0;
    public static Weapon GetWeapon { get; private set; }
    public virtual void Awake()
    {
        GetWeapon = this;
        WeaponDamage = BaseDamage;
    }

    public abstract void Attack(Vector3 direction, Vector3 atackPoint);

    public void SetDamageWeapon(int value)
    {
        BaseDamage = value;
        if (WeaponDamage < BaseDamage)
            WeaponDamage = BaseDamage;
    }

    public void AddDamage(int value)
    {
        MoreDamage = value;
    }

    public virtual void AddModifier(ModifierPrepare modifier)
    {
        ModifierPrepare containedMod = _modifiers
            .Find(mod => mod.GetModifierInfo().GetModifierType == modifier.GetModifierInfo().GetModifierType);

        if (containedMod is null)
            _modifiers.Add(modifier);
        else
            containedMod.SetModifierInfo(modifier.GetModifierInfo());
    }
}
