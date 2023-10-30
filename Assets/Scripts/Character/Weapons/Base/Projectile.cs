using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected internal int Damage;
    public Action OnProjectileCollision;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(Damage);
        }
        
        if (OnProjectileCollision == null) //Modifier check
        {
            Destroy(gameObject);
            return;
        }
        OnProjectileCollision();
        Destroy(gameObject);
    }
}
