using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Chain Lightning Config", menuName = "Modifiers/ChainLightning")]
public class ChainLightningConfig : ModifierBaseObject
{
    [SerializeField] private float _radius = 2;
    [SerializeField] private int _damage = 5;
    [SerializeField] private int _additionalTargets = 3;
    [SerializeField, Range(1,100)] private int _chance = 20;
    protected new Type _modifierType = typeof(ChainLightningModifier);
    public float Radius => _radius;
    public int Damage => _damage;
    public int AdditionalTargets => _additionalTargets;
    public int Chance => _chance;
    public override Type GetModifierType => _modifierType;
    public override ModifierTarget GetModifierTarget => ModifierTarget.Weapon;
}
