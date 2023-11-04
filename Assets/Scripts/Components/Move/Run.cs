using System;
using UnityEngine;


[RequireComponent(typeof(Move))]
public class Run : MonoBehaviour
{
    [SerializeField]
    private float _speedScale = 2f;
    private Move _move;

    public void Awake()
    {
        _move = GetComponent<Move>();
    }
    public void Move(Rigidbody2D rb,Vector2 direction)
    {
        rb.velocity = direction * UnityEngine.Random.Range(_speedScale * 0.9f, _speedScale * 1.1f);
    }
    
    public void OnEnable()
    {
        _move.OnMove += Move;
    }
    public void OnDisable()
    {   
        _move.OnMove -= Move;
    }
}
