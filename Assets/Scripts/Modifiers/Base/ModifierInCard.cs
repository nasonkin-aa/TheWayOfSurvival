using UnityEngine;
public enum ModifierTarget
{
    Character,
    Weapon,
    Campfire
}

public class ModifierInCard : MonoBehaviour
{
    public ModifierBaseObject modifierInfo;

    public void Activate ()
    {
        var mod = new ModifierPrepare(modifierInfo);
        ModifierAdder.AddModifier(mod, Player.Instance, modifierInfo.GetModifierTarget);
    }

    public void CopyFromSO(ModifierBaseObject card) => modifierInfo = card;
}
