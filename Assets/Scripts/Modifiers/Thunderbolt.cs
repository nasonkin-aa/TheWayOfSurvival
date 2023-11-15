using UnityEngine;

[RequireComponent(typeof(Overlaper))]
public class Thunderbolt : MonoBehaviour, IWeaponModifier
{
    protected static ThunderboltConfig _thunderboltInfo;
    protected static string _particlePath = "Particle\\Electric\\Prefabs\\Thunderbolt";
    protected static GameObject _particleObj;
    protected ParticleSystem _particle;
    public void Awake()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
        _particleObj ??= Resources.Load(_particlePath) as GameObject;
    }

    protected void Start()
    {
        _particle ??= GetComponentInChildren<ParticleSystem>();
    }

    private void OnDisable()
    {
        GetComponentInParent<Projectile>().OnProjectileCollision -= DealDamage;
    }

    void IWeaponModifier.PrepareModifier(ModifierBaseObject thunderboltInfo)
    {
        //Instantiate(_particleObj, transform);
        _thunderboltInfo = thunderboltInfo as ThunderboltConfig;
        GetComponentInParent<Projectile>().OnProjectileCollision += DealDamage;
    }

    private void DealDamage()
    {
        //_particle.Play(false);
        var collidedObjects = GetComponent<Overlaper>().CircleOverlap(_thunderboltInfo.Radius, Projectile.ContactWithEnemies);
        collidedObjects.ForEach(collider => collider.GetComponent<HealthBase>()?.TakeDamage(_thunderboltInfo.AreaDamage));
    }

    public void UpdateModifierInfo(ModifierBaseObject modifierConfig)
    {
        _thunderboltInfo = modifierConfig as ThunderboltConfig;
    }
}
