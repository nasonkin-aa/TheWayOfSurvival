using UnityEngine;

public class CharacterModifier : ModifierBase
{
    public IWeaponModifier mod;
    public CharacterModifier(IWeaponModifier mod, Player player)
    {
        this.player = player;
        this.mod = mod;
    }


    public override void AddModifier()
    {
        
    }
}
