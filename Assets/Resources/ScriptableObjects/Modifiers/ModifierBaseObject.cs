using UnityEngine;

public class ModifierBaseObject : ScriptableObject
{
    [SerializeField] protected int _lvl = 1;
    [SerializeField] protected string _description = "";
    [SerializeField] protected ModifierName _modifierName = ModifierName.ElectricAOE;
    [SerializeField] protected ModifierTarget _modifierTarget = ModifierTarget.Weapon;

    public int Lvl => _lvl;
    public string Description => _description;
    public virtual ModifierName GetModifierName => _modifierName;
    public virtual ModifierTarget GetModifierTarget => _modifierTarget;
}

