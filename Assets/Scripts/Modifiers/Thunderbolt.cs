using UnityEngine;

[RequireComponent(typeof(Overlaper))]
public class Thunderbolt : MonoBehaviour, IWeaponModifier
{
    protected static ThunderboltConfig _thunderboltInfo;
    protected static string _particlePrefabPath = "Particle\\Electric\\Prefabs\\Thunderbolt";
    protected static GameObject _particlePrefab;
    protected ParticleSystem _particle;
    public void Awake()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
        _particlePrefab ??= Resources.Load(_particlePrefabPath) as GameObject;
    }

    protected void Start()
    {
        
    }

    private void OnDisable()
    {
        if (GetComponentInParent<Projectile>() is null)
            return;
        GetComponentInParent<Projectile>().OnProjectileCollision -= DealDamage; //Make error when scene reload and thunderbolt spawn
    }

    void IWeaponModifier.PrepareModifier(ModifierBaseObject thunderboltInfo)
    {
        _thunderboltInfo = thunderboltInfo as ThunderboltConfig;

        if (GetComponentInParent<Projectile>() is null)
            return;

        GetComponentInParent<Projectile>().OnProjectileCollision += DealDamage;
    }

    private void DealDamage(Collision2D collision)
    {
        if ( collision.gameObject.layer != 9) // 9 = enemy layer
            return;

        var collidedObjects = GetComponent<Overlaper>().CircleOverlap(_thunderboltInfo.Radius, Projectile.ContactWithEnemies);
        collidedObjects.ForEach(collider => collider.GetComponent<HealthBase>()?.TakeDamage(_thunderboltInfo.AreaDamage));

        var thunderObj = Instantiate(_particlePrefab);
        thunderObj.transform.position = new (transform.position.x, thunderObj.transform.position.y);
        thunderObj.GetComponentInChildren<ParticleSystem>()?.Play(false);
        Destroy(thunderObj, 3);
    }

    public void UpdateModifierInfo(ModifierBaseObject modifierConfig) => 
        _thunderboltInfo = modifierConfig as ThunderboltConfig;
}
