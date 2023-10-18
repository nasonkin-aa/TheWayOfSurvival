using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Move))]
public class Run : MonoBehaviour
{
    private Move _move;
    public void Awake()
    {
        _move = GetComponent<Move>();
    }
    public void Move(Rigidbody2D rb,Vector2 direction)
    {
        rb.velocity = direction * 2;
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
