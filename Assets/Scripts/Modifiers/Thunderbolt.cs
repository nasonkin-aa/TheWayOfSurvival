using UnityEngine;

[RequireComponent(typeof(Overlaper))]
public class Thunderbolt : Modifier
{
    protected static int AOEDamage = 20;
    protected static int radius = 20;

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
    public override void PrepareModifier()
    {
        GetComponentInParent<Projectile>().OnProjectileCollision += ActivateEffect;
    }
}
