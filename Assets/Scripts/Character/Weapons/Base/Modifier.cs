using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifier : MonoBehaviour, IWeaponModifier
{
    [SerializeField] protected GameObject _prefab;
    public virtual void ActivateEffect()
    {
        
    }

    public virtual GameObject CreateSubObject(Transform parent)
    {
        GameObject subObject = Instantiate(new GameObject("Modifier"), parent);
        subObject.transform.parent = parent;
        subObject.transform.position = parent.position;
        return subObject;
    }
}
