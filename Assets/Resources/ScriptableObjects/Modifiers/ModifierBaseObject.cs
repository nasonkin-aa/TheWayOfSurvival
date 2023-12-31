using System;
using UnityEngine;
using UnityEngine.UI;

public class ModifierBaseObject : ScriptableObject
{
    [SerializeField] protected string _name = "";
    [SerializeField] protected Sprite _icon;
    [SerializeField] protected int _lvl = 1;
    [SerializeField] protected string _description = "";
    protected Type _modifierType = typeof(ElectricAOE);

    public int Lvl => _lvl;

    public string Name => _name;
    public Sprite Icon => _icon;
    public string Description => _description;
    public virtual Type GetModifierType => _modifierType;
    public virtual ModifierTarget GetModifierTarget => ModifierTarget.Weapon;
}

