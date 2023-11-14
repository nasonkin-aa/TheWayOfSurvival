using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Rage Config", menuName = "Modifiers/Rage")]
public class RageConfig : ModifierBaseObject
{
    protected new Type _modifierType = typeof(Rage);
    protected new ModifierTarget _modifierTarget = ModifierTarget.Character;
    [SerializeField, Range(.5f, 100)] protected float _scale = 1;

    public override Type GetModifierType => _modifierType;

    public override ModifierTarget GetModifierTarget => _modifierTarget;
    public float GetScale => _scale;

}
