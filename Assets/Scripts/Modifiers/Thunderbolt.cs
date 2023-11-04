using UnityEngine;

[RequireComponent(typeof(Overlaper))]
public class Thunderbolt : MonoBehaviour, IWeaponModifier
{
    protected static int AOEDamage = 20;
    protected static int radius = 20;

    public void Awake()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        GetComponentInParent<Projectile>().OnProjectileCollision -= DealDamage;
    }

    public void PrepareModifier()
    {
        GetComponentInParent<Projectile>().OnProjectileCollision += DealDamage;
    }

    private void DealDamage()
    {
        var collidedObjects = GetComponent<Overlaper>().CircleOverlap(radius, Projectile.ContactWithEnemies);
        collidedObjects.ForEach(collider => collider.GetComponent<HealthBase>()?.TakeDamage(AOEDamage));
    }
}
