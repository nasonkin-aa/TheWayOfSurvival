using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Overlaper))]
public class ElectricAOE : Modifier
{
    public static int AOEDamage = 20;
    private static int radius = 100;
    public void Awake()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
    }
    public override void ActivateEffect()
    {
        base.ActivateEffect();
        var collidedObjects = GetComponent<Overlaper>().CircleOverlap(radius, new ContactFilter2D());
        collidedObjects.ForEach(collider => collider.GetComponent<Health>()?.TakeDamage(AOEDamage));
    }
    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    public override GameObject CreateSubObject(Transform parent)
    {
        var newSubObj = SubObjectsCreator.CreateSubObjectWithModifier(parent, this);
        parent.GetComponent<Projectile>().OnProjectileCollision += newSubObj.GetComponent<ElectricAOE>().ActivateEffect;
        return newSubObj;
    }
}
