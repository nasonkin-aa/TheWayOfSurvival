using UnityEngine;

public interface IMovable
{
    public void Move(Rigidbody2D rb,Vector2 direction);
    public void Stop(Rigidbody2D rb);

    public void ScaleSpeed(float value);
}
