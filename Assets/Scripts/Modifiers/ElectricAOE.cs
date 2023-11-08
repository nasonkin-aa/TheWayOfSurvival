using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Overlaper))]
public class ElectricAOE : MonoBehaviour, IWeaponModifier
{
    protected static int _AOEDamage = 20;
    protected static int _radius = 3;
    protected static float _interval = .5f; // В секундах
    protected static string _particlePath = "Particle\\Electric\\Prefabs\\ElectricitySphere";
    protected static GameObject _particleObj;
    protected ParticleSystem _particle;

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
    public void PrepareModifier()
    {
        StartCoroutine(DamageOverTime());
        Instantiate(_particleObj, transform);
    }
    private void DealDamage()
    {
        var collidedObjects = GetComponent<Overlaper>().CircleOverlap(_radius, Projectile.ContactWithEnemies);
        collidedObjects.ForEach(collider => collider.GetComponent<Health>()?.TakeDamage(_AOEDamage));
    }


    IEnumerator DamageOverTime()
    {
        for (;;)
        {
            yield return new WaitForSeconds(_interval);
            DealDamage();
            _particle.Play(false);
        }
    }
}
