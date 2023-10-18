using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Move))]
public class Jump : MonoBehaviour
{
    private Move _move;
    public void Awake()
    {
        _move = GetComponent<Move>();
    }

    public void Move(Rigidbody2D rb,Vector2 direction)
    {
        rb.AddForce(( Vector2.up) * 15 );
    }
    public void OnEnable()
    {
        _move.Go  += Move;
    }
    public void OnDisable()
    {   
        _move.Go  -= Move;
    }
}
