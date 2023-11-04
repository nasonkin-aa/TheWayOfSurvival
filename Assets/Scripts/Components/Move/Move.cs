using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Move : MoveBase
{
    public GameObject target;

    public Action<Rigidbody2D, Vector2> OnMove;
        
    private Rigidbody2D _rd;
    private void Awake()
    {
        _rd = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (target == null)
            return;
        OnMove?.Invoke(_rd, GetDirectionToObject(target.transform));
        Flip(-GetDirectionToObject(target.transform).x, gameObject);
    }

    public Vector2 GetDirectionToObject(Transform playerTransform)
    {
        return ( playerTransform.position - transform.position).normalized;
    }
}