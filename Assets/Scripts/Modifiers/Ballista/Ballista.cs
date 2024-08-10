using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Ballista : MonoBehaviour
{
    private bool _IsRechargeOver = true;
    private GameObject _knifePrefab;
    private bool _isRotating = false;
    private BallistaZone _ballistaZone;
    protected static BallistaConfig _ballistaInfo;
    
    /*private float _rotationSpeed = 5f;
    private float _rechargeTime = 3f;*/
    public void Start()
    {
        _ballistaZone = transform.parent.GetComponentInChildren<BallistaZone>();
        _ballistaZone.OnCollisionWithEnemy += CheckToAttack;
        _knifePrefab = Resources.Load("Weapons/BallistaProjectile") as GameObject;
    }
    
    public void CheckToAttack(Collider2D other)
    {
        if (_IsRechargeOver)
        {
            Vector3 enemyPosition = other.transform.position;
            StartCoroutine(RotateTowardsEnemy(enemyPosition));
            _IsRechargeOver = false;
        }
    }
    
    IEnumerator Shoot(Vector2 other)
    {
        SpawnKnifeWhithRototion(other);
        yield return new WaitForSeconds(_ballistaInfo.GetRechargeTime); 
        _IsRechargeOver = true;
    }
    IEnumerator RotateTowardsEnemy(Vector3 enemyPosition)
    {
        _isRotating = true;
        
        Vector2 direction = transform.parent.parent.transform.localScale.x * (enemyPosition - transform.position);
        direction.Normalize();

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        while (_isRotating)
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.AngleAxis(targetAngle, Vector3.forward);
            
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, Time.deltaTime * _ballistaInfo.GetRotationSpeed);
            if (Quaternion.Angle(transform.rotation, targetRotation) < 1f)
            {
                StartCoroutine(Shoot(enemyPosition));
                _isRotating = false;
            }
            yield return null;
        }
    }
    
    public void SpawnKnifeWhithRototion(Vector2 other)
    {
        Vector3 direction = other - (Vector2)transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        var bolt = Instantiate(_knifePrefab, transform.position, rotation);
        bolt.GetComponent<Knife>().PrepareKnife(_ballistaInfo.GetBoltSpeed, (int)_ballistaInfo.GetBoltDamage);
        AudioManager.Instance.Play("BallistaProjectile");
        Destroy(bolt,3f);
        
    }
    public void SetBallistaInfo(BallistaConfig BallistaInfo)
    {
        _ballistaInfo = BallistaInfo;
    }

}
