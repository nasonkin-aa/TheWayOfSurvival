using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IAttackable
{
    protected List<ModifierPrepare> _modifiers = new ();
    [field: SerializeField, Range(0, 1000)] public int BaseDamage { get; protected set; } = 10;
    [field: SerializeField, Range(0, 1000)] public int WeaponDamage { get; protected set; } = 0;
    
    [field: SerializeField, Range(0, 1000)] public int MoreDamageAxe { get; private set; } = 0;
    [field: SerializeField, Range(0, 1000)] public float MoreDamageRage { get; private set; } = 0;
    [field: SerializeField, Range(0, 1000)] public float RageInfoScale { get; private set; } = 0;

    private int _damageFromConfig;
    public static Weapon Inctance { get; private set; }
    
    public virtual void Awake()
    {
        Inctance = this;
    }

    public abstract void Attack(Vector3 direction, Vector3 atackPoint);

    public void SetDamageWeapon(float value)
    {
        MoreDamageRage = value;
    }

    public void AddDamage(int value)
    {
        MoreDamageAxe = value;
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
