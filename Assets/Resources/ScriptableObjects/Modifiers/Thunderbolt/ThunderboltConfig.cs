using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Thunderbolt Config", menuName = "Modifiers/Thunderbolt" )]
public class ThunderboltConfig : ModifierBaseObject
{
    [SerializeField] private float _radius = 2;
    [SerializeField] private int _areaDamage = 20;
    [SerializeField] private int _frequency = 4;
    protected new Type _modifierType = typeof(Thunderbolt);
    public float Radius => _radius;
    public int AreaDamage => _areaDamage;
    public int Frequency => _frequency;
    public override Type GetModifierType => _modifierType;
    public override ModifierTarget GetModifierTarget => ModifierTarget.Weapon;
}
