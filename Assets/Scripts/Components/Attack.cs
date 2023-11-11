using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private AttackZone _attackZone;
    public int damage = 10;
    public Action OnAttackReady;
    public Action OnAttackFinished;
    private Health _targetToAttack;
    public void Start()
    {
        _attackZone = GetComponentInChildren<AttackZone>();
        _attackZone.OnCollisionWithTarget += ContactWithTarget;
        Debug.Log(_attackZone.OnCollisionWithTarget);
    }

    public void AttackZoneTarget()
    {
        _attackZone.AttackTarget(damage);
    }

    public void ContactWithTarget(Health health)
    {
        Debug.Log(health + " 1");
        _targetToAttack = health;
        OnAttackReady?.Invoke();
    }

    public void CheckTargetToAttack()
    {
        if (_attackZone.CheckTargetInCollider() == _targetToAttack)
            _targetToAttack?.TakeDamage(damage);

        _targetToAttack = null;
        OnAttackFinished?.Invoke();
    }
}
