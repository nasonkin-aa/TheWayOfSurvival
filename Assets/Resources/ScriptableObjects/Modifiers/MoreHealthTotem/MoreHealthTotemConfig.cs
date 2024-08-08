using System;
using UnityEngine;

[CreateAssetMenu(fileName = "More Health Totem Config", menuName = "Modifiers/MoreHealthTotem")]
public class MoreHealthTotemConfig : ModifierBaseObject
{
    protected new Type _modifierType = typeof(MoreHealthTotem);
    [SerializeField, Range(1, 1000)] protected int _additionalHealth = 1;

    public override Type GetModifierType => _modifierType;

    public override ModifierTarget GetModifierTarget => ModifierTarget.Character;
    public int AdditionalHealth => _additionalHealth;
}
