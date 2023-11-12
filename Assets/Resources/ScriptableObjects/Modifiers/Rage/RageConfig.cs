using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Rage Config", menuName = "Modifiers/Rage")]
public class RageConfig : ModifierBaseObject
{
    protected new Type _modifierType = typeof(Rage);

    public override Type GetModifierType => _modifierType;

}
