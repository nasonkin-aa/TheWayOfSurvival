using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveController : MoveBase
{
    public Transform target;
    protected IMovable Mover;
    protected Rigidbody2D _rd;
    protected void Awake()
    {
        Mover = GetComponent<IMovable>();
        _rd = GetComponent<Rigidbody2D>();
    }

    public virtual void MoveToTarget()
    {
        if (target is null)
            return;
        Mover.Move(_rd,GetDirectionToObject(target));
        Flip(-GetDirectionToObject(target.transform).x, gameObject);
    }

    public Vector2 GetDirectionToObject(Transform targetTransform)
    {
        var direction = (Vector2)(targetTransform.position - transform.position);
        return direction.normalized;
    }

    public void Stop()
    {
        Mover.Stop(_rd);
    }
}
