using System.Collections;
using UnityEngine;

public interface IWeaponModifier
{
    public void ActivateEffect();
    public GameObject CreateSubObject(Transform parent);
}
