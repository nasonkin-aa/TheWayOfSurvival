using System;
using UnityEngine;

[CreateAssetMenu(fileName = "More Health Character Config", menuName = "Modifiers/MoreHealthCharacter")]
public class MoreHealthCharacterConfig : ModifierBaseObject
{
    protected new Type _modifierType = typeof(MoreHealthCharacter);
    [SerializeField, Range(1, 1000)] protected int _additionalHealth = 1;

    public override Type GetModifierType => _modifierType;

    public override ModifierTarget GetModifierTarget => ModifierTarget.Character;
    public int GetAdditionalHealth => _additionalHealth;
}
