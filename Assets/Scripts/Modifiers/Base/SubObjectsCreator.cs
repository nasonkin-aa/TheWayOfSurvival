using UnityEngine;
using System;
public class SubObjectsCreator 
{
    public static GameObject CreateSubObject (Transform parent, string name)
    {
        GameObject subObject = new GameObject(name);
        subObject.transform.parent = parent;
        subObject.transform.position = parent.position;
        return subObject;
    }

    public static GameObject CreateSubObjectWithModifier(Transform parent, Type mod)
    {
        var subObject = CreateSubObject(parent, mod.ToString());
        subObject.AddComponent(mod);
        return subObject;
    }
}
