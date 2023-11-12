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
    private HealthBase _targetToAttack;
    public void Start()
    {
        _attackZone = GetComponentInChildren<AttackZone>();
        _attackZone.OnCollisionWithTarget += ContactWithTarget;
    }

    public void ContactWithTarget(HealthBase health)
    {
        _targetToAttack = health;
        OnAttackReady?.Invoke();
    }

    public void CheckTargetToAttack()
    {
        var collideHealth = _attackZone.CheckTargetInCollider();
        if (collideHealth is not null && collideHealth == _targetToAttack)
        {
            _targetToAttack?.TakeDamage(damage);
        }
        else
        {
            _targetToAttack = null;
            OnAttackFinished?.Invoke();
        }
    }
}
