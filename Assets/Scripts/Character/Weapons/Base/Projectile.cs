using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Action OnProjectileCollision;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(10);
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
