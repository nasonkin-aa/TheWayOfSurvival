using UnityEngine;

public class TotemHealthForSouls : MonoBehaviour, IWeaponModifier
{
    protected static TotemHealthForSoulsConfig _totemRegenInfo;
    protected static Player _player;
    protected static Health _totemHealth;

    private void Awake()
    {
        _player = Player.Instance;
        _totemHealth = Totem.Instance.Health;
    }

    private void OnDisable()
    {
        _player.SoulPickUpEvent -= RegenerateHealth;
    }
    void IWeaponModifier.PrepareModifier(ModifierBaseObject totemRegenInfo)
    {
        _totemRegenInfo = totemRegenInfo as TotemHealthForSoulsConfig;

        _player.SoulPickUpEvent += RegenerateHealth;
    }

    public void UpdateModifierInfo(ModifierBaseObject totemRegenInfo)
    {
        if (_totemRegenInfo is null)
            return;

        _totemRegenInfo = totemRegenInfo as TotemHealthForSoulsConfig;
    }
    
    private void RegenerateHealth()
    {
        _totemHealth.Heal(_totemRegenInfo.GetRegeneratedHealth);
    }
}
