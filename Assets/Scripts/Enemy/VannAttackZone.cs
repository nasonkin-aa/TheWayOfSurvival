using UnityEngine;

public class VannAttackZone : AttackZone
{
    protected override void Start()
    {
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _circleCollider2D.radius = Random.Range(_circleCollider2D.radius * 0.9f, _circleCollider2D.radius * 1.1f);
        contactFilter2D.useLayerMask = true;
    }
}
