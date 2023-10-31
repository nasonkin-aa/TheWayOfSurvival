using UnityEngine;
public enum ModifierTarget
{
    Character,
    Weapon
}

public enum ModifierName
{
    ElectricAOE,
    Thunderbolt
}
public class ModifierInCard : MonoBehaviour
{
    public ModifierTarget modifierTarget;
    public ModifierName modifierName;

    public void Activate ()
    {
        var mod = new ModifierPrepare(modifierName.ToString());
        ModifierAdder.AddModifier(mod, PlayerStatic.PlayerScript, modifierTarget);
    }
}
