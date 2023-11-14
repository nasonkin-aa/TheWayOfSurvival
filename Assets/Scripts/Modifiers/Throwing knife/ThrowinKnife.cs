using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class ThrowinKnife : MonoBehaviour
{
    private GameObject _target;
    [SerializeField]
    private GameObject _knifePrefab;
    private int _countKnife = 3;
    private float _reloadTime = 2;
    private float _timeBetwinShot = 0.3f;

    private bool _RechargeOver = true;

    private string _path = "Weapons/Knife";
    
    private Collider2D[] enemyColliders;
    public ContactFilter2D contactFilter2D;
    private CircleCollider2D _circleCollider2D;
    private void Start()
    {
        _knifePrefab = Resources.Load(_path) as GameObject;
        _circleCollider2D = GetComponent<CircleCollider2D>();
        contactFilter2D.useLayerMask = true;
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<BaseEnemy>() && _RechargeOver)
        {
            StartCoroutine(MyCoroutine(other));
            _RechargeOver = false;
        }
    }
     IEnumerator MyCoroutine(Collider2D other)
    {
        for(int i = 0; i < _countKnife; i++)
        {
            yield return new WaitForSeconds(0.2f); 
            List<Collider2D> targets = OverlapTargetWithHp();
            if (targets is not null)
                SpawnKnifeWhithRototion(targets[Random.Range(0,targets.Count)]);
        }
        yield return new WaitForSeconds(_reloadTime); 
        _RechargeOver = true;
    }

    public void SpawnKnifeWhithRototion(Collider2D other)
    {
        Vector3 direction = other.transform.position - transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        var obj = Instantiate(_knifePrefab, transform.position, rotation);
        Destroy(obj,3f);
        
    }
    private List<Collider2D> OverlapTargetWithHp()
    {
        var collider2Ds = new List<Collider2D>();
        var countOverlapCollider = _circleCollider2D.OverlapCollider(contactFilter2D, collider2Ds);
        if (countOverlapCollider > 0)
            return collider2Ds;
        return null;
    }
    
}
