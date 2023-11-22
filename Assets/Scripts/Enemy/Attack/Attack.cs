using System;
using UnityEngine;

public class Attack : MonoBehaviour
{
    protected AttackZone _attackZone;
    public int damage = 10;
    public Action OnAttackReady;
    public Action OnAttackFinished;
    protected HealthBase _targetToAttack;
    
 
    public virtual void Start()
    {
        _attackZone = GetComponentInChildren<AttackZone>();
        _attackZone.OnCollisionWithTarget += ContactWithTarget;
    }

    public virtual void ContactWithTarget(HealthBase health)
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
        }
    }

    public void CheckAttackFinish()
    {
        OnAttackFinished?.Invoke();
    }

    public void SetTrget(HealthBase target)
    {
        _targetToAttack = target;
    }
}
