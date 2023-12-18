using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Rage Config", menuName = "Modifiers/Rage")]
public class RageConfig : ModifierBaseObject
{
    protected new Type _modifierType = typeof(Rage);
    [SerializeField, Range(.01f, 100)] protected float _scale = 1;

    public override Type GetModifierType => _modifierType;

    public override ModifierTarget GetModifierTarget => ModifierTarget.Character;
    public float GetScale => _scale;

}
