using System.Collections.Generic;
using UnityEngine;

public class ElectricAOE : MonoBehaviour, IWeaponModifier
{
    public static int AOEDamage = 20;
    private static int radius = 100;
    public void ActivateEffect()
    {
        var collidedObjects = Overlaper.CircleOverlap(transform.position, radius, new ContactFilter2D());
        collidedObjects.ForEach(collider => collider.GetComponent<Health>()?.TakeDamage(AOEDamage));
        //transform.parent.GetComponent<Projectile>().OnProjectileCollision -= this.ActivateEffect;
    }
    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    GameObject IWeaponModifier.CreateSubObject(Transform parent)
    {
        GameObject subObject = Instantiate(GameObject.Find("Empty"), parent);
        subObject.transform.parent = parent;
        subObject.transform.position = parent.position;
        var newModifier = subObject.AddComponent<ElectricAOE>();
        parent.GetComponent<Projectile>().OnProjectileCollision += newModifier.ActivateEffect;
        return subObject;
    }
}
