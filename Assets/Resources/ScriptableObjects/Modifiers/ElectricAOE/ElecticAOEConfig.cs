using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ElectricAOE Config", menuName = "Modifiers/ElectricAOE")]
public class ElectricAOEConfig : ModifierBaseObject
{
    [SerializeField] private float _radius = 2;
    [SerializeField] private int _areaDamage = 20;
    [SerializeField] private float _interval = 1.5f;
    protected new Type _modifierType = typeof(ElectricAOE);

    public float Radius => _radius;
    public int AreaDamage => _areaDamage;
    public float Interval => _interval;
    public override Type GetModifierType => _modifierType;

}
