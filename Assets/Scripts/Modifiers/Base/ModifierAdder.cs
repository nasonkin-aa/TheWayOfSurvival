public static class ModifierAdder
{
    public static void AddModifier(ModifierPrepare mod, Player player, ModifierTarget target)
    {
        switch (target)
        {
            case ModifierTarget.Character:
                player?.AddModifier(mod);
                break;

            case ModifierTarget.Weapon:
                player?.Weapon?.AddModifier(mod);
                break;
            case ModifierTarget.Campfire:
                Campfire.instance?.AddModifier(mod);
                    break;
        }
    }
}
