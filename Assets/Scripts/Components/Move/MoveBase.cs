using System;
using UnityEngine;

public abstract class MoveBase : MonoBehaviour
{
    public Action OnFlip;

    protected virtual void Flip(float direction, GameObject gameObj)
    {
        var localScale = gameObj.transform.localScale;
        if ((direction > 0 && localScale.x < 0) || (direction < 0 && localScale.x > 0))
        {
            localScale.x = -localScale.x;
            gameObj.transform.localScale = localScale;
            OnFlip?.Invoke();
        }
    }
}
