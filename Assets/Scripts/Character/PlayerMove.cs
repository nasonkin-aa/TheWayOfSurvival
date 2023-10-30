using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GroundChecker))]
public class PlayerMove : MonoBehaviour
{
    private readonly int _jumpConstanta = 60;
    [SerializeField]
    public float _speed = 0.4f;
    [SerializeField]
    public float jumpForce = 10;
    private Rigidbody2D _rb;
    
    void Start()
    {
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

    public void OnEnable()
    {
        PlayerInput.OnPlayerMoveHorizontal += Move;
        PlayerInput.OnPlayerJump += Jump;
    }
    public void OnDisable()
    {
        PlayerInput.OnPlayerMoveHorizontal -= Move;
        PlayerInput.OnPlayerJump -= Jump;
    }
}
