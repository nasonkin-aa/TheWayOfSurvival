using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Overlaper))]
public class ElectricAOE : MonoBehaviour, IWeaponModifier
{
    protected static string _particlePath = "Particle\\Electric\\Prefabs\\ElectricitySphere";
    protected static GameObject _particleObj;
    protected ParticleSystem _particle;
    protected static ElectricAOEConfig _electricAOEInfo;

    protected void Awake()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
        _particleObj ??= Resources.Load(_particlePath) as GameObject;
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
        Debug.Log(_electricAOEInfo);
        StartCoroutine(DamageOverTime());
        Instantiate(_particleObj, transform);
    }
    private void DealDamage()
    {
        var collidedObjects = GetComponent<Overlaper>().CircleOverlap(_electricAOEInfo.Radius, Projectile.ContactWithEnemies);
        collidedObjects.ForEach(collider => collider.GetComponent<Health>()?.TakeDamage(_electricAOEInfo.AreaDamage));
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
}
