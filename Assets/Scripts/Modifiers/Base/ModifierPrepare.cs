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
}
