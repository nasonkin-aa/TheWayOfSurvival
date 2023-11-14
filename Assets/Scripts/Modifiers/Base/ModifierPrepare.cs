using UnityEngine;
using System;

public class ModifierPrepare 
{
    private readonly Type _modifier;
    private ModifierBaseObject _modifierInfo;

    public ModifierPrepare(ModifierBaseObject modifierInfo)
    {
        _modifier = modifierInfo.GetModifierType;
        _modifierInfo = modifierInfo;
    }
    public GameObject CreateSubObject(Transform parent)
    {   
        var newSubObj = SubObjectsCreator.CreateSubObjectWithModifier(parent, _modifier);
        var newModifier = newSubObj.GetComponent(_modifier) as IWeaponModifier;
        newModifier?.PrepareModifier(_modifierInfo); // Настройка модификатора

        return newSubObj;
    }

    public void LvlUpModifier(ModifierBaseObject modifierInfo)
    {
        if (modifierInfo is null ||
            _modifierInfo.GetModifierType != modifierInfo.GetModifierType ||
            _modifierInfo.Lvl + 1 != modifierInfo.Lvl)
            return;

        _modifierInfo = modifierInfo;
    }

    public ModifierBaseObject GetModifierInfo() => _modifierInfo;
    public void SetModifierInfo(ModifierBaseObject modifierInfo)
    {
        _modifierInfo = modifierInfo;
    }
    public void SetModifierInfo(ModifierBaseObject modifierInfo, Transform transform)
    {
        var mod = transform.GetComponentInChildren(typeof(IWeaponModifier)) as IWeaponModifier;
        Debug.Log(mod);
        if (mod is null)
            return;

        mod.UpdateModifierInfo(modifierInfo);
    }
}

