using UnityEngine;

public class Fly : MonoBehaviour,IMovable
{
    [SerializeField]
    public float speedScale = 2f;
    public void Move(Rigidbody2D rb, Vector2 direction)
    {
        rb.velocity =  direction * UnityEngine.Random.Range(speedScale * 0.9f, speedScale * 1.1f);
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
