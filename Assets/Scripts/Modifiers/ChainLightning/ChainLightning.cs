using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLightning : MonoBehaviour
{
    
    public int Damage;
    public int AdditionalTargets;

    private CircleCollider2D _circleCollider;
    [SerializeField] private LayerMask _enemyLayer;

    [SerializeField] private GameObject _chainLightningPrefab;
    [SerializeField] private GameObject _beenStruckPrefab;


    [SerializeField] private GameObject _startObject;
    public GameObject _endObject;

    private Animator _animator;

    [SerializeField] private ParticleSystem _particleSystem;

    private int _singleSpawn;

    private void Start()
    {
        if (AdditionalTargets == 0) Destroy(gameObject);

        _animator = GetComponent<Animator>();
        _particleSystem = GetComponent<ParticleSystem>();
        _circleCollider = GetComponent<CircleCollider2D>();
        _startObject = gameObject;

        _singleSpawn = 1;
        Destroy(gameObject, .4f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.layer + " --------- " + _enemyLayer.value);
        //Debug.Log(_enemyLayer == (_enemyLayer | (1 << collision.gameObject.layer)));

        if (_enemyLayer == (_enemyLayer | (1 << collision.gameObject.layer)) && !collision.GetComponentInChildren<EnemyStruck>() )
        {
            if (_singleSpawn != 0)
            {
                _singleSpawn--;
                Debug.Log(_enemyLayer == (_enemyLayer | (1 << collision.gameObject.layer)));
                _endObject = collision.gameObject;

                AdditionalTargets -= 1;
                Instantiate(_chainLightningPrefab, collision.gameObject.transform.position, Quaternion.identity);

                Instantiate(_beenStruckPrefab, collision.gameObject.transform);

                collision.gameObject.GetComponent<Health>()?.TakeDamage(Damage);

                _animator.StopPlayback();
                _circleCollider.enabled = false;

                _particleSystem.Play();

                var emitParams = new ParticleSystem.EmitParams();

                emitParams.position = _startObject.transform.position;
                _particleSystem.Emit(emitParams, 1);

                emitParams.position = _endObject.transform.position;
                _particleSystem.Emit(emitParams, 1);

                emitParams.position = (_startObject.transform.position + _endObject.transform.position) / 2;
                _particleSystem.Emit(emitParams, 1);

                Destroy(gameObject, .4f);
            }

        }

    }

}
