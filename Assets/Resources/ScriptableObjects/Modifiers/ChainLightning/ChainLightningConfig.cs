using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Chain Lightning Config", menuName = "Modifiers/ChainLightning")]
public class ChainLightningConfig : ModifierBaseObject
{
    [SerializeField] private float _radius = 2;
    [SerializeField] private int _damage = 5;
    [SerializeField] private int _targets = 3;
    protected new Type _modifierType = typeof(ChainLightning);
    public float Radius => _radius;
    public int Damage => _damage;
    public int Targets => _targets;
    public override Type GetModifierType => _modifierType;
    public override ModifierTarget GetModifierTarget => ModifierTarget.Weapon;
}
