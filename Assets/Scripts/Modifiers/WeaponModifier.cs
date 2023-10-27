using UnityEngine;

public class WeaponModifier : ModifierBase
{
    protected IWeaponModifier mod;
    protected Weapon GetWeapon => player.GetWeapon();

    public WeaponModifier(IWeaponModifier mod, Player player)
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
