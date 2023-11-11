using System;
using UnityEngine;

public abstract class MoveBase : MonoBehaviour
{
    public Action OnFlip;

    protected virtual void Flip(float direction, GameObject gameObj)
    {
        var localScale = gameObj.transform.localScale;
        if (direction * localScale.x >= 0)
            return;
        
        localScale.x = -localScale.x;
        gameObj.transform.localScale = localScale;
        OnFlip?.Invoke();
    }
}
