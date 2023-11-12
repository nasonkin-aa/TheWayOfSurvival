using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
//[RequireComponent(typeof(IMovable))]
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

    public Vector2 GetDirectionToObject(Transform playerTransform)
    {
        return ( playerTransform.position - transform.position).normalized;
    }
}
