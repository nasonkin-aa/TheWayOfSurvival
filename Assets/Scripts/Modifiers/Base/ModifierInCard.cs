using UnityEngine;
public enum ModifierTarget
{
    Character,
    Weapon
}

public class ModifierInCard : MonoBehaviour
{
    public ModifierTarget modifierTarget;
    public ModifierName modifierName;

    public void Activate ()
    {
        var mod = new ModifierPrepare(modifierName.ToString());
        ModifierAdder.AddModifier(mod, Player.GetPlayer, modifierTarget);
    }

    public void Copy(ModifierInCard card)
    {
        modifierTarget = card.modifierTarget;
        modifierName = card.modifierName;
    }
}
