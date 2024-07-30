using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreHealthCharacter : MonoBehaviour, IWeaponModifier
{
    protected static MoreHealthCharacterConfig _moreHealthCharacterInfo;
    protected static Health _health;

    private void Awake()
    {
        _health = Player.GetPlayer.GetHealth();
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        
    }
    void IWeaponModifier.PrepareModifier(ModifierBaseObject moreHealthCharacterInfo)
    {
        _moreHealthCharacterInfo = moreHealthCharacterInfo as MoreHealthCharacterConfig;

        _health.MaxHealth += _moreHealthCharacterInfo.GetAdditionalHealth;
    }

    public void UpdateModifierInfo(ModifierBaseObject moreHealthCharacterInfo)
    {
        if (_moreHealthCharacterInfo is null)
            return;

        _moreHealthCharacterInfo = moreHealthCharacterInfo as MoreHealthCharacterConfig;

        _health.MaxHealth += _moreHealthCharacterInfo.GetAdditionalHealth;
    }

}
