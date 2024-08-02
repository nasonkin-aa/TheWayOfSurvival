using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLightning : MonoBehaviour, IWeaponModifier
{
    protected static ChainLightningConfig _chainLightningInfo;
    protected static string _particlePrefabPath = "Particle\\Electric\\Prefabs\\ChainLightning";
    protected static GameObject _chainLightningPrefab;
    protected static int _timesHit = 0;
    protected ParticleSystem _particle;

    public void Awake()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
        _chainLightningPrefab ??= Resources.Load(_particlePrefabPath) as GameObject;
    }

    public void PrepareModifier(ModifierBaseObject modifierConfig)
    {
        _chainLightningInfo = modifierConfig as ChainLightningConfig;

        
        Instantiate(_chainLightningPrefab, transform.position, Quaternion.identity);
    }

    public void UpdateModifierInfo(ModifierBaseObject modifierConfig)
    {
        throw new System.NotImplementedException();
    }
}
