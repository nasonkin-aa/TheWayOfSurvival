using Souls;
using UnityEngine;

public class TotemHealthForSouls : MonoBehaviour, IWeaponModifier
{
    protected static TotemHealthForSoulsConfig TotemRegenInfo;
    protected static Health TotemHealth;

    private void Awake()
    {
        TotemHealth = Totem.Instance.Health;
    }

    private void OnDisable()
    {
        SoulCollector.PickUpEvent -= RegenerateHealth;
    }
    void IWeaponModifier.PrepareModifier(ModifierBaseObject totemRegenInfo)
    {
        TotemRegenInfo = totemRegenInfo as TotemHealthForSoulsConfig;

        SoulCollector.PickUpEvent += RegenerateHealth;
    }

    public void UpdateModifierInfo(ModifierBaseObject totemRegenInfo)
    {
        if (TotemRegenInfo is null)
            return;

        TotemRegenInfo = totemRegenInfo as TotemHealthForSoulsConfig;
    }
    
    private void RegenerateHealth(int value)
    {
        TotemHealth.Heal(TotemRegenInfo.GetRegeneratedHealth);
    }
}
