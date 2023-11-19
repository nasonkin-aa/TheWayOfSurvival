using System;
using UnityEngine;
[CreateAssetMenu(fileName = "Ballista Config", menuName = "Modifiers/Ballista")]
public class BallistaConfig : ModifierBaseObject
{
    protected new Type _modifierType = typeof(BallistaPrepare);
    [SerializeField, Range(.1f, 30)] protected float _rotationSpeed = 5;
    [SerializeField, Range(.1f, 30)] protected float _rechargeTime = 3;
    [SerializeField, Range(5, 100)] protected float _BoltSpeed = 20;
    [SerializeField, Range(10, 1000)] protected int _BoltDamage = 30;
    private string _path = "Weapons/ballista";
    public override Type GetModifierType => _modifierType;
    public override ModifierTarget GetModifierTarget => ModifierTarget.Character;

    public float GetRotationSpeed => _rotationSpeed;
    public float GetRechargeTime => _rechargeTime;
    public float GetBoltSpeed => _BoltSpeed;
    public float GetBoltDamage => _BoltDamage;

    public string GetPrefabPath => _path;

}
