using UnityEngine;
public enum ModifierTarget
{
    Character,
    Weapon
}

public class ModifierInCard : MonoBehaviour
{
    public ModifierBaseObject modifierInfo;

    public void Activate ()
    {
        Debug.Log(modifierInfo.GetModifierTarget);
        var mod = new ModifierPrepare(modifierInfo);
        ModifierAdder.AddModifier(mod, Player.GetPlayer, modifierInfo.GetModifierTarget);
    }

    public void CopyFromSO(ModifierBaseObject card)
    {
        modifierInfo = card;
    }
}
