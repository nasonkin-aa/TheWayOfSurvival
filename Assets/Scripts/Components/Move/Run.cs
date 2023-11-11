using System;
using UnityEngine;


//[RequireComponent(typeof(MoveController))]
public class Run : MonoBehaviour, IMovable
{
    [SerializeField]
    private float _speedScale = 2f;
    public void Move(Rigidbody2D rb,Vector2 direction)
    {
        rb.velocity = direction * UnityEngine.Random.Range(_speedScale * 0.9f, _speedScale * 1.1f);
    }
    
}
