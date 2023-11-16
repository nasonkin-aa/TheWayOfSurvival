using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Overlaper))]
public class ElectricAOE : MonoBehaviour, IWeaponModifier
{
    protected static string _particlePrefabPath = "Particle\\Electric\\Prefabs\\ElectricitySphere";
    protected static GameObject _particlePrefab;
    protected ParticleSystem _particle;
    protected static ElectricAOEConfig _electricAOEInfo;

    protected void Awake()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
        _particlePrefab ??= Resources.Load(_particlePrefabPath) as GameObject;
    }

    protected void Start()
    {
        _particle ??= GetComponentInChildren<ParticleSystem>();
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
    void IWeaponModifier.PrepareModifier(ModifierBaseObject electricAOEInfo)
    {
        _electricAOEInfo = electricAOEInfo as ElectricAOEConfig;
        StartCoroutine(DamageOverTime());
        Instantiate(_particlePrefab, transform);
    }
    private void DealDamage()
    {
        var collidedObjects = GetComponent<Overlaper>().CircleOverlap(_electricAOEInfo.Radius, Projectile.ContactWithEnemies);
        collidedObjects.ForEach(collider => 
            collider.GetComponent<Health>()?.TakeDamage(_electricAOEInfo.AreaDamage));
    }


    IEnumerator DamageOverTime()
    {
        for (;;)
        {
            yield return new WaitForSeconds(_electricAOEInfo.Interval);
            DealDamage();
            _particle.Play(false);
        }
    }

    public void UpdateModifierInfo(ModifierBaseObject modifierConfig) =>
        _electricAOEInfo = modifierConfig as ElectricAOEConfig;
}
