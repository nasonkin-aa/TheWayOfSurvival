using UnityEngine;

public class ChainLightningModifier : MonoBehaviour, IWeaponModifier
{
    protected static ChainLightningConfig _chainLightningInfo;
    protected static string _chainLightningPrefabPath = "Particle\\Electric\\Prefabs\\ChainLightning\\ChainLightningPrefab";
    protected static string _beenStruckPath = "Particle\\Electric\\Prefabs\\ChainLightning\\EnemyStruck";
    protected static GameObject _chainLightningPrefab;
    protected GameObject _beenStruck;
    protected static Projectile _projectile;
    protected static int _timesHit = 0;
    protected ParticleSystem _particle;
    [SerializeField] private LayerMask _enemyLayer;
    public void Awake()
    {
        _enemyLayer = LayerMask.NameToLayer("Enemy");
        //GetComponent<CircleCollider2D>().isTrigger = true;
        _chainLightningPrefab = Resources.Load<GameObject>(_chainLightningPrefabPath);
        _beenStruck = Resources.Load<GameObject>(_beenStruckPath);

        _projectile = GetComponentInParent<Projectile>();
    }

    private void OnDisable()
    {
    }

    public void PrepareModifier(ModifierBaseObject modifierConfig)
    {
        _chainLightningInfo = modifierConfig as ChainLightningConfig;

        if (_projectile == null)
            return;


        _projectile.OnProjectileCollision += SpawnChainLightning;

        
    }

    public void UpdateModifierInfo(ModifierBaseObject modifierConfig)
    {
        _chainLightningInfo = modifierConfig as ChainLightningConfig;
    }

    private void SpawnChainLightning(Collision2D target)
    {
        int random = Random.Range(0, 100);
        if (_enemyLayer.value == target.gameObject.layer &&
            !target.gameObject.GetComponentInChildren<EnemyStruck>())
        {
            if (random > _chainLightningInfo.Chance) return;
            GameObject chainLightning;

            Instantiate(_beenStruck, target.gameObject.transform);
            chainLightning = Instantiate(_chainLightningPrefab, target.gameObject.transform.position, Quaternion.identity);
            chainLightning.GetComponent<ChainLightning>().Damage = _chainLightningInfo.Damage;
            chainLightning.GetComponent<ChainLightning>().AdditionalTargets = _chainLightningInfo.AdditionalTargets;

            target.gameObject.GetComponent<Health>()?.TakeDamage(_chainLightningInfo.Damage);
            _projectile.OnProjectileCollision -= SpawnChainLightning;

        }
        GetComponentInParent<Projectile>().OnProjectileCollision -= SpawnChainLightning;
        

    }
}
