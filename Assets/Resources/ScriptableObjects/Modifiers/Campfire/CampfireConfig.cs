using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Campfire Config", menuName = "Modifiers/Campfire")]
public class CampfireConfig : ModifierBaseObject
{
    [SerializeField] private float _radius = 20;
    [SerializeField] private int _healAmount = 20;
    [SerializeField] private int _reloadTime = 20;
    protected new Type _modifierType = typeof(Campfire);
    public float Radius => _radius;
    public int HealAmount => _healAmount;
    public int ReloadTime => _reloadTime;
    public override Type GetModifierType => _modifierType;
    public override ModifierTarget GetModifierTarget => ModifierTarget.Campfire;
}
