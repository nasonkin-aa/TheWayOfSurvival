using UnityEngine;

[RequireComponent(typeof(Overlaper))]
public class Thunderbolt : MonoBehaviour, IWeaponModifier
{
    protected static ThunderboltConfig _thunderboltInfo;

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

    void IWeaponModifier.PrepareModifier(ModifierBaseObject thunderboltInfo)
    {
        _thunderboltInfo = thunderboltInfo as ThunderboltConfig;
        GetComponentInParent<Projectile>().OnProjectileCollision += DealDamage;
    }

    private void DealDamage()
    {
        var collidedObjects = GetComponent<Overlaper>().CircleOverlap(_thunderboltInfo.Radius, Projectile.ContactWithEnemies);
        collidedObjects.ForEach(collider => collider.GetComponent<HealthBase>()?.TakeDamage(_thunderboltInfo.AreaDamage));
    }

    public void UpdateModifierInfo(ModifierBaseObject modifierConfig)
    {
        _thunderboltInfo = modifierConfig as ThunderboltConfig;
    }
}
