using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLightningScript : MonoBehaviour
{
    
    private CircleCollider2D _circleCollider;
    [SerializeField] private LayerMask _enemyLayer;
    public int Damage;

    [SerializeField] private GameObject _chainLightningPrefab;
    [SerializeField] private GameObject _beenStruckPrefab;

    public int Targets;

    private GameObject _startObject;
    public GameObject _endObject;

    private Animator _animator;

    [SerializeField] private ParticleSystem _particleSystem;

    private void Start()
    {
        if (Targets == 0) Destroy(gameObject);

        _animator = GetComponent<Animator>();
        _particleSystem = GetComponent<ParticleSystem>();
        _circleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (_enemyLayer == (_enemyLayer | (1 << collision.gameObject.layer)) && !collision.GetComponentInChildren<EnemyStruck>())
        {
            _endObject = collision.gameObject;

            Targets -= 1;
            Instantiate(_chainLightningPrefab, collision.gameObject.transform.position, Quaternion.identity);

            Instantiate(_beenStruckPrefab, collision.gameObject.transform);

            collision.gameObject.GetComponent<HealthBase>().TakeDamage(Damage);

            _animator.StopPlayback();
            _circleCollider.enabled = false;

            _particleSystem.Play();

            var emitParams = new ParticleSystem.EmitParams();
            emitParams.position = _startObject.transform.position;

            _particleSystem.Emit(emitParams, 1);

            emitParams.position = _endObject.transform.position;

            _particleSystem.Emit(emitParams, 1);

            Destroy(gameObject, 1f);
        }

    }

}
