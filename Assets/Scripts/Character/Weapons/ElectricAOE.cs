using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElectricAOE : MonoBehaviour, IWeaponModifier
{
    private Collider2D _AOECollider;
    public static int AOEDamage = 20;
    private static int radius = 100;
    private void Awake()
    {       
        _AOECollider = GetComponent<Collider2D>();
    }
    public void ActivateEffect()
    {
        //List<Health> collision = new();
        List<Collider2D> colliders = new();
        _AOECollider.OverlapCollider(new ContactFilter2D(), colliders);
        colliders.ForEach(collider => collider.GetComponent<Health>()?.TakeDamage(AOEDamage));
    }
    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    public static GameObject CreateSubObject(Transform parent)
    {
        GameObject subObject = Instantiate(GameObject.Find("Empty"), parent);
        subObject.transform.position = parent.position;
        var subCollider = subObject.AddComponent<CircleCollider2D>();
        subCollider.radius = radius;
        subCollider.isTrigger = true;
        subObject.AddComponent<ElectricAOE>();
        return subObject;
    }
}
