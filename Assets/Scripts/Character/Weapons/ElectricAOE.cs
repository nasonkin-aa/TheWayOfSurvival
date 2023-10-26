using System.Collections.Generic;
using UnityEngine;

public class ElectricAOE : Modifier
{
    public static int AOEDamage = 20;
    private static int radius = 100;
    public void Awake()
    {

    }
    public override void ActivateEffect()
    {
        base.ActivateEffect();
        var collidedObjects = Overlaper.CircleOverlap(transform.position, radius, new ContactFilter2D());
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
        GameObject subObject = base.CreateSubObject(parent);
        var newModifier = subObject.AddComponent<ElectricAOE>();
        parent.GetComponent<Projectile>().OnProjectileCollision += newModifier.ActivateEffect;
        return subObject;
    }
}
