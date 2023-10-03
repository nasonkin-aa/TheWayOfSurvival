using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GroundChecker))]
public class PlayerMove : MonoBehaviour
{
    private readonly int _jumpConstanta = 60;
    private float _speed = 0.4f;
    private Rigidbody2D _rb;
    public float jumpForce = 10;
    
    void Start()
    {
        transform.GetComponentInChildren<GroundChecker>();
        PlayerInput.OnPlayerMoveHorizontal += Move;
        PlayerInput.OnPlayerJump += Jump;
        _rb = transform.GetComponent<Rigidbody2D>();
    }

    private void Move(float direction)
    {
        Vector3 newPositioin = new Vector3((direction * _speed), 0, 0);
        transform.position += newPositioin;
    }

    private void Jump()
    {
        if (GroundChecker.IsPayerOnTheGround)
        {
            _rb.AddForce(Vector2.up * jumpForce * _jumpConstanta);
            
        }
    }

    ~PlayerMove()
    {
        PlayerInput.OnPlayerMoveHorizontal -= Move;
        PlayerInput.OnPlayerJump -= Jump;
    }
    
   
}
