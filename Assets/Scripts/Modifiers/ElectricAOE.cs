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
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    void IWeaponModifier.PrepareModifier(ModifierBaseObject electricAOEInfo)
    {
        _electricAOEInfo = electricAOEInfo as ElectricAOEConfig;
        Instantiate(_particlePrefab, transform);
        StartCoroutine(DamageOverTime());
        
    }
    private void DealDamage()
    {
        var collidedObjects = GetComponent<Overlaper>().CircleOverlap(_electricAOEInfo.Radius, Projectile.ContactWithEnemies);
        collidedObjects.ForEach(collider => 
            collider.GetComponent<Health>()?.TakeDamage(_electricAOEInfo.AreaDamage));
    }
    
    IEnumerator DamageOverTime()
    {
        yield return new WaitForSeconds(_electricAOEInfo.Interval / 2);
        DealDamage();
        _particle.Play(false);
        AudioManager.Instance.Play("ElectricAOE");
        for (;;)
        {
            yield return new WaitForSeconds(_electricAOEInfo.Interval);
            DealDamage();
            _particle.Play(false);
            AudioManager.Instance.Play("ElectricAOE");
        }
    }

    public void UpdateModifierInfo(ModifierBaseObject modifierConfig) =>
        _electricAOEInfo = modifierConfig as ElectricAOEConfig;
}
