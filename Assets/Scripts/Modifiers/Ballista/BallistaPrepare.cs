using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;

using UnityEngine;

public class BallistaPrepare : MonoBehaviour, IWeaponModifier
{
    protected List<Ballista> balists = new List<Ballista>(); 
    void IWeaponModifier.PrepareModifier(ModifierBaseObject BallistaInfo)
    {
        var ballistaCponfig = BallistaInfo as BallistaConfig;
        var prefab = Resources.Load(ballistaCponfig.GetPrefabPath);
        var obj = Instantiate(prefab, Vector2.zero, quaternion.identity) as GameObject;
        var obj2 = Instantiate(prefab, Vector2.zero, quaternion.identity) as GameObject;
        obj2.transform.localScale = new Vector3(-1, 1, 1);
        balists.Add(obj.GetComponentInChildren<Ballista>());
        balists.Add(obj2.GetComponentInChildren<Ballista>());
        balists.ForEach(ballista => ballista.SetBallistaInfo(ballistaCponfig));
    }
    public void UpdateModifierInfo(ModifierBaseObject BallistaInfo)
    {
        balists.ForEach(ballista => ballista.SetBallistaInfo(BallistaInfo as BallistaConfig));
    }
    
}
