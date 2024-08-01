using System;
using UnityEngine;

[CreateAssetMenu(fileName = "MoreDamageAxe Config", menuName = "Modifiers/MoreDamageAxe")]
public class MoreDamageAxeConfig : ModifierBaseObject
{
    protected new Type _modifierType = typeof(MoreDamageAxe);
    [SerializeField, Range(.01f, 100)] protected float _damage = 1;

    public override Type GetModifierType => _modifierType;

    public override ModifierTarget GetModifierTarget => ModifierTarget.Weapon;
    public float GetDamage => _damage;
}
