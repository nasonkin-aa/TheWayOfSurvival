using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IAttackable
{
    protected List<ModifierPrepare> _modifiers = new ();
    public int WeaponDamage;

    public virtual void Attack(Vector3 direction, Vector3 atackPoint)
    {

    }
    public void SetDamageWeapon(int value)
    {
        WeaponDamage = value;
    }
    

    public virtual void AddModifier(ModifierPrepare modifier)
    {
        _modifiers.Add(modifier);
    }
}
