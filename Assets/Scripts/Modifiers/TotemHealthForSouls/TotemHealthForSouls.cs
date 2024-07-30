using UnityEngine;

public class TotemHealthForSouls : MonoBehaviour, IWeaponModifier
{
    protected static TotemHealthForSoulsConfig _totemRegenInfo;
    protected static Player _player;
    protected static HealthBase _totemHealth;

    private void Awake()
    {
        _player = Player.GetPlayer;
        _totemHealth = Totem.GetTotem.GetComponent<TotemHealth>();
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        _player.SoulPickUp -= RegenerateHealth;
    }
    void IWeaponModifier.PrepareModifier(ModifierBaseObject totemRegenInfo)
    {
        _totemRegenInfo = totemRegenInfo as TotemHealthForSoulsConfig;

        _player.SoulPickUp += RegenerateHealth;
    }

    public void UpdateModifierInfo(ModifierBaseObject totemRegenInfo)
    {
        if (_totemRegenInfo is null)
            return;

        _totemRegenInfo = totemRegenInfo as TotemHealthForSoulsConfig;
    }
    
    private void RegenerateHealth()
    {
        _totemHealth.GetHeal(_totemRegenInfo.GetRegeneratedHealth);
    }
}
