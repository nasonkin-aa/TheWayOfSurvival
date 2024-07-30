using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectiles : Projectile
{
    protected void OnTriggerEnter2D(Collider2D other)
    {
        //if (_isContact) return; //Hack for kill 1 enemy 1 projectile
        
        other.gameObject.GetComponent<Health>()?.TakeDamage(Damage);
        
        //OnProjectileCollision?.Invoke();
        //_isContact = true;
        Destroy(gameObject);
    }
}
