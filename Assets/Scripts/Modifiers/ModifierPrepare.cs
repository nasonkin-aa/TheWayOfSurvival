using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ModifierPrepare 
{
    private Type modifier;

    public ModifierPrepare(Type modifier)
    {
        this.modifier = modifier;
    }
    public GameObject CreateSubObject(Transform parent)
    {
        
        var newSubObj = SubObjectsCreator.CreateSubObjectWithModifier(parent, modifier);
        parent.GetComponent<Projectile>().OnProjectileCollision += newSubObj.GetComponent<Modifier>().ActivateEffect;
        return newSubObj;
    }
}
