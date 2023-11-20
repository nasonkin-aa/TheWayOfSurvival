using UnityEngine;

public class VannMove : MoveController
{
    private bool IsRunAway = false;
    public override void MoveToTarget()
    {
        if (target is null)
            return;

        var direction = GetDirectionToObject(target);
        var distance = GetDistance(target);
        var colliderRadius = GetComponentInChildren<AttackZone>().GetComponent<CircleCollider2D>().radius;

        if (Mathf.Abs(distance) < Mathf.Abs(colliderRadius * transform.localScale.x / 2 / 2))
            IsRunAway = true;
        if (Mathf.Abs(distance) > Mathf.Abs(colliderRadius * transform.localScale.x / 2))
            IsRunAway = false;

        if (IsRunAway)
            direction = -direction;

        Mover.Move(_rd, direction);
        Flip(-direction.x, gameObject);
    }

    private float GetDistance(Transform targetTransform)
    {
        var direction = (Vector2)(targetTransform.position - transform.position);
        return direction.magnitude;
    }
}
