using System;
using UnityEngine;

public class ModifierBaseObject : ScriptableObject
{
    [SerializeField] protected int _lvl = 1;
    [SerializeField] protected string _description = "";
    [SerializeField] protected ModifierTarget _modifierTarget = ModifierTarget.Weapon;
    protected Type _modifierType = typeof(ElectricAOE);

    public int Lvl => _lvl;
    public string Description => _description;
    public virtual Type GetModifierType => _modifierType;
    public virtual ModifierTarget GetModifierTarget => _modifierTarget;
}

