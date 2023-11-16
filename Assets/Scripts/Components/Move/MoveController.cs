using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveController : MoveBase
{
    public Transform target;
    private IMovable Mover;
    private Rigidbody2D _rd;
    private void Awake()
    {
        Mover = GetComponent<IMovable>();
        _rd = GetComponent<Rigidbody2D>();
    }

    public void MoveToTarget()
    {
        if (target is null)
            return;
        Mover.Move(_rd,GetDirectionToObject(target));
        Flip(-GetDirectionToObject(target.transform).x, gameObject);
    }

    public Vector2 GetDirectionToObject(Transform targetTransform)
    {
        //var directionX = (targetTransform.position.x - transform.position.x);
        //var directionY = (targetTransform.position.y - transform.position.y);
        //Vector2 direction = new (directionX, directionY);
        var direction = (Vector2)(targetTransform.position - transform.position);
        return direction.normalized;
        //return direction.normalized;
    }
}
