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
        Flip(direction.x);
    }
    
    private void Flip(float direction)
    {
        var localScale = gameObject.transform.localScale;
        
        if ((direction < 0 && localScale.x < 0) || (direction > 0 && localScale.x > 0))
        {
            localScale.x *= -1;
            gameObject.transform.localScale = localScale;
        }
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
