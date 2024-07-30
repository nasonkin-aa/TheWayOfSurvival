using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Totem Health For Souls Config", menuName = "Modifiers/TotemHealthForSouls")]
public class TotemHealthForSoulsConfig : ModifierBaseObject
{
    protected new Type _modifierType = typeof(TotemHealthForSouls);
    [SerializeField, Range(1, 1000)] protected int _regeneratedlHealth = 1;

    public override Type GetModifierType => _modifierType;

    public override ModifierTarget GetModifierTarget => ModifierTarget.Character;
    public int GetRegeneratedHealth => _regeneratedlHealth;
}
