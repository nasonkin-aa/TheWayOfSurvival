using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(CircleCollider2D))]
public class AttackZone : MonoBehaviour
{
    public ContactFilter2D contactFilter2D;

    private CircleCollider2D _circleCollider2D;
    private Health _targetHealth;

    public Action<Health> OnCollisionWithTarget;
    private void Start()
    {
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _circleCollider2D.radius = Random.Range( _circleCollider2D.radius, _circleCollider2D.radius * 2f);
        contactFilter2D.useLayerMask = true;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        var health = OverlapTargetWithHp();
        if (health == null)
            return;
        Debug.Log(health);
        OnCollisionWithTarget?.Invoke(health);
    }

    public Health CheckTargetInCollider()
    {
        return OverlapTargetWithHp();
    }

    private Health OverlapTargetWithHp()
    {
        var collider2Ds = new List<Collider2D>();
        var countOverlapCollider = _circleCollider2D.OverlapCollider(contactFilter2D, collider2Ds);
        if (countOverlapCollider > 0)
            return collider2Ds[0].gameObject.GetComponent<Health>();
        return null;
    }

    public void AttackTarget(int value) //Used by Animator Attack
    {
        if(_targetHealth != null)
            _targetHealth.TakeDamage(value);
    }
}