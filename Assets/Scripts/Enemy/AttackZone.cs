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

    public Action<HealthBase> OnCollisionWithTarget;
    private void Start()
    {
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _circleCollider2D.radius = Random.Range( _circleCollider2D.radius, _circleCollider2D.radius * 2f);
        contactFilter2D.useLayerMask = true;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log(other.name);
        var health = OverlapTargetWithHp();
        if (health == null)
            return;
        OnCollisionWithTarget?.Invoke(health);
    }

    public HealthBase CheckTargetInCollider()
    {
        return OverlapTargetWithHp();
    }

    private HealthBase OverlapTargetWithHp()
    {
        var collider2Ds = new List<Collider2D>();
        var countOverlapCollider = _circleCollider2D.OverlapCollider(contactFilter2D, collider2Ds);
        if (countOverlapCollider > 0)
            return collider2Ds[0].gameObject.GetComponent<HealthBase>();
        return null;
    }

}