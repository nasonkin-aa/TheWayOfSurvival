using UnityEngine;

public class WeaponModifier : ModifierBase
{
    protected ModifierPrepare mod;
    protected Weapon GetWeapon => player.GetWeapon();

    public WeaponModifier(ModifierPrepare mod, Player player)
    {
        this.mod = mod;
        this.player = player;
    }

    public override void AddModifier()
    {
        if (GetWeapon == null)
            return;

        GetWeapon.AddModifier(mod);
    }
}
