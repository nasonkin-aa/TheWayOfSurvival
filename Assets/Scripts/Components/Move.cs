using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Move : MonoBehaviour
{
    [SerializeField]
    private PlayerMove _player;

    public Action<Rigidbody2D,Vector2> Go;
        
    private Rigidbody2D _rd;
    private void Awake()
    {
        _rd = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_player == null)
            return;
        Debug.Log("123");
        Debug.Log(Go);
        Go(_rd, GetPlayerDirection(_player.transform));
    }

    public Vector2 GetPlayerDirection(Transform playerTransform)
    {
        return ( playerTransform.position - transform.position).normalized;
    }
}
