using System.Collections.Generic;
using UnityEngine;

public class FairyAttackZone : AttackZone
{
    protected override void Start()
    {
        _circleCollider2D = GetComponent<CircleCollider2D>();
        contactFilter2D.useLayerMask = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.gameObject.GetComponent<HealthBase>();
        OnCollisionWithTarget?.Invoke(health);
    }

    public override void OnTriggerStay2D(Collider2D other)
    {

    }

    public HealthBase CheckTargetInCollider(HealthBase target)
    {
        return OverlapTargetWithHp(target);
    }

    protected HealthBase OverlapTargetWithHp(HealthBase target)
    {
        var collider2Ds = new List<Collider2D>();
        var countOverlapCollider = _circleCollider2D.OverlapCollider(contactFilter2D, collider2Ds);
        var healthCollided = collider2Ds.ConvertAll(coll => coll.gameObject.GetComponent<HealthBase>()); // Залупа

        if (healthCollided.Contains(target))
            return target;
        return null;      
    }
}
