using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected internal int Damage = 10;
    public Action OnProjectileCollision;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Health>()?.TakeDamage(Damage);

        if (OnProjectileCollision is not null) //Modifier check
            OnProjectileCollision();

        Destroy(gameObject);
    }
}
