using System;
using UnityEngine;


//[RequireComponent(typeof(MoveController))]
public class Run : MonoBehaviour, IMovable
{
    [SerializeField]
    public float speedScale = 2f;
    public void Move(Rigidbody2D rb,Vector2 direction)
    {
        float speedMultiplier = UnityEngine.Random.Range(speedScale * 0.9f, speedScale * 1.1f);
        rb.velocity =  new Vector2(direction.x * speedMultiplier,rb.velocity.y);
    }

    public void Stop(Rigidbody2D rb)
    {
        rb.velocity = Vector2.zero;
    }
    public void ScaleSpeed(float value)
    {
        speedScale *= value;
    }
}
