using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IAttackable
{
    protected List<IWeaponModifier> _modifiers = new ();

    public virtual void Attack(Vector3 direction, Vector3 atackPoint)
    {

    }

    public virtual void AddModifier(IWeaponModifier modifier)
    {
        _modifiers.Add(modifier);
    }
}
