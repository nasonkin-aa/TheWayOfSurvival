using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Overlaper))]
public class ElectricAOE : MonoBehaviour, IWeaponModifier
{
    protected static int AOEDamage = 20;
    protected static int radius = 3;
    protected static float interval = .5f; // В секундах

    public void Awake()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
    public void PrepareModifier()
    {
        StartCoroutine(DamageOverTime());
    }
    private void DealDamage()
    {
        var collidedObjects = GetComponent<Overlaper>().CircleOverlap(radius, Projectile.ContactWithEnemies);
        collidedObjects.ForEach(collider => collider.GetComponent<Health>()?.TakeDamage(AOEDamage));
    }


    IEnumerator DamageOverTime()
    {
        for (;;)
        {
            yield return new WaitForSeconds(interval);
            DealDamage();
        }
    }
}
