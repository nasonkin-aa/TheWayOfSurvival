using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreHealthTotem : MonoBehaviour, IWeaponModifier
{
    protected static MoreHealthTotemConfig _moreHealthTotemInfo;
    protected static Health _health;

    private void Awake()
    {
        _health = Totem.GetTotem.Health;
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }
    void IWeaponModifier.PrepareModifier(ModifierBaseObject moreHealthTotemInfo)
    {
        _moreHealthTotemInfo = moreHealthTotemInfo as MoreHealthTotemConfig;

        _health.MaxHealth += _moreHealthTotemInfo.AdditionalHealth;
    }

    public void UpdateModifierInfo(ModifierBaseObject moreHealthTotemInfo)
    {
        if (_moreHealthTotemInfo is null)
            return;

        _moreHealthTotemInfo = moreHealthTotemInfo as MoreHealthTotemConfig;

        _health.MaxHealth += _moreHealthTotemInfo.AdditionalHealth;
    }
}
