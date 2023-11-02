using UnityEngine;
using System;
public class ModifierPrepare 
{
    private readonly Type _modifier;

    public ModifierPrepare(Type modifier)
    {
        _modifier = modifier;
    }
    public ModifierPrepare(string modifierName)
    {
        _modifier = Type.GetType(modifierName);
    }
    public GameObject CreateSubObject(Transform parent)
    {   
        var newSubObj = SubObjectsCreator.CreateSubObjectWithModifier(parent, _modifier);
        var newModifier = (Modifier)newSubObj.GetComponent(_modifier);
        newModifier?.PrepareModifier(); // Настройка модификатора

        return newSubObj;
    }
}
