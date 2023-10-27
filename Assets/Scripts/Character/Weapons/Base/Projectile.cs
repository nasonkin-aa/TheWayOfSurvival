using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Action OnProjectileCollision;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (OnProjectileCollision == null)
        {
            Destroy(gameObject);
            return;
        }
        OnProjectileCollision();
        Destroy(gameObject);
    }
}
