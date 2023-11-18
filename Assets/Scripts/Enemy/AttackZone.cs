using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(CircleCollider2D))]
public class AttackZone : MonoBehaviour
{
    public ContactFilter2D contactFilter2D;

    protected CircleCollider2D _circleCollider2D;

    public Action<HealthBase> OnCollisionWithTarget;
    protected virtual void Start()
    {
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _circleCollider2D.radius = Random.Range( _circleCollider2D.radius, _circleCollider2D.radius * 2f);
        contactFilter2D.useLayerMask = true;
    }

    public virtual void OnTriggerStay2D(Collider2D other)
    {
        var health = OverlapTargetWithHp();
        if (health == null)
            return;
        OnCollisionWithTarget?.Invoke(health);
    }

    public HealthBase CheckTargetInCollider()
    {
        return OverlapTargetWithHp();
    }

    protected HealthBase OverlapTargetWithHp()
    {
        var collider2Ds = new List<Collider2D>();
        var countOverlapCollider = _circleCollider2D.OverlapCollider(contactFilter2D, collider2Ds);
        if (countOverlapCollider > 0)
            return collider2Ds[0].gameObject.GetComponent<HealthBase>();
        return null;
    }
}