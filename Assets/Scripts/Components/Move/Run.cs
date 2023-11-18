using System;
using UnityEngine;


//[RequireComponent(typeof(MoveController))]
public class Run : MonoBehaviour, IMovable
{
    [SerializeField]
    private float _speedScale = 2f;
    public void Move(Rigidbody2D rb,Vector2 direction)
    {
        float speedMultiplier = UnityEngine.Random.Range(_speedScale * 0.9f, _speedScale * 1.1f);
        rb.velocity =  new Vector2(direction.x * speedMultiplier,rb.velocity.y);
    }

    public void Stop(Rigidbody2D rb)
    {
        rb.velocity = Vector2.zero;
    }
}
