using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ThrowingKnife Config", menuName = "Modifiers/ThrowingKnife")]
public class ThrowingKnifeConfig : ModifierBaseObject
{
    protected new Type _modifierType = typeof(ThrowingKnife);

    [SerializeField, Range(1, 30)] protected int _countKnife = 3;
    [SerializeField, Range(.1f, 10)] protected float _reloadTime = 2;
    [SerializeField, Range(.1f, 10)] protected float _timeBetwinShot = 0.3f;
    [SerializeField, Range(5, 100)] protected float _knifeSpeed = 20;
    [SerializeField, Range(10, 1000)] protected int _knifeDamage = 20;
    private string _path = "Weapons/ThrowingKnife";

    public override Type GetModifierType => _modifierType;

    public override ModifierTarget GetModifierTarget => ModifierTarget.Character;

    public int GetCountKnife => _countKnife;
    public float GetReloadTime => _reloadTime;
    public float GetTimeBetwinShot => _timeBetwinShot;
    public string GetPrefabPath => _path;
    public float GetKnifeSpeed => _knifeSpeed;
    public int GetKnifeDamage => _knifeDamage;

}
