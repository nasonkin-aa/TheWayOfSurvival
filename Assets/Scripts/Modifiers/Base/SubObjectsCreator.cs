using Unity.VisualScripting;
using UnityEngine;
using System;
public class SubObjectsCreator 
{
    public static GameObject CreateSubObject (Transform parent)
    {
        GameObject subObject = new GameObject("SubObject");
        subObject.transform.parent = parent;
        subObject.transform.position = parent.position;
        return subObject;
    }

    public static GameObject CreateSubObjectWithModifier(Transform parent, Type mod)
    {
        var subObject = CreateSubObject(parent);
        subObject.AddComponent(mod);
        return subObject;
    }
}
