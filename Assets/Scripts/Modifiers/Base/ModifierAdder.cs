
public static class ModifierAdder
{
    public static void AddModifier(ModifierPrepare mod, Player player, ModifierTarget target)
    {
        switch (target)
        {
            case ModifierTarget.Character:
                PlayerStatic.PlayerScript.AddModifier(mod);
                break;

            case ModifierTarget.Weapon:
                player?.GetWeapon()?.AddModifier(mod);
                break;
        }
    }
}
