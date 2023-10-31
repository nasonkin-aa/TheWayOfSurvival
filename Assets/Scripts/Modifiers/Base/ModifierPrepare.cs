using UnityEngine;
using System;
public class ModifierPrepare 
{
    private Type modifier;

    public ModifierPrepare(Type modifier)
    {
        this.modifier = modifier;
    }
    public ModifierPrepare(string modifierName)
    {
        modifier = Type.GetType(modifierName);
    }
    public GameObject CreateSubObject(Transform parent)
    {   
        var newSubObj = SubObjectsCreator.CreateSubObjectWithModifier(parent, modifier);
        var newModifier = (Modifier)newSubObj.GetComponent(modifier);
        newModifier?.PrepareModifier(); // Настройка модификатора

        return newSubObj;
    }
}
