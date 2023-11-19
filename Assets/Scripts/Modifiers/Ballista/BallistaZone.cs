using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaZone : MonoBehaviour
{
    public Action<Collider2D> OnCollisionWithEnemy;
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<BaseEnemy>())
        {
            OnCollisionWithEnemy?.Invoke(other);
        }
    }
}
