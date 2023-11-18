using System.Collections;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Random = UnityEngine.Random;

public class FairyMoveController : MoveController
{
    protected bool IsMoving = false;
    public void MoveRandom()
    {
        if (target is null || IsMoving)
            return;

        IsMoving = true;
        var time = Random.Range(1, 1.5f);
        StartCoroutine(MoveSomeTime(time));

        Mover.Move(_rd, GetRandomDirection(target));
        Flip(-GetDirectionToObject(target.transform).x, gameObject);
    }

    protected Vector2 GetRandomDirection(Transform target)
    {
        var direction = (Vector2)(target.position - transform.position);
        var angle = UnityEngine.Random.Range(90, 270);
        return RotateVector(direction.normalized, angle);
    }

    protected Vector2 RotateVector (Vector2 vectorStart, float angle)
    {
        var rotatedX = vectorStart.x * Mathf.Cos(angle) - vectorStart.y * Mathf.Sin(angle);
        var rotatedY = vectorStart.x * Mathf.Sin(angle) + vectorStart.y * Mathf.Cos(angle);
        return new(rotatedX, rotatedY);
    }

    protected IEnumerator MoveSomeTime(float time)
    {
        yield return new WaitForSeconds(time);
        IsMoving = false;
    }
}
