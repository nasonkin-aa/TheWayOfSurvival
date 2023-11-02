using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected internal int Damage;
    private bool _isContact = false;
    public Action OnProjectileCollision;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isContact) return; //Hack for kill 1 enemy 1 projectile
        
        collision.gameObject.GetComponent<Health>()?.TakeDamage(Damage);

        if (OnProjectileCollision is not null) //Modifier check
            OnProjectileCollision();
        _isContact = true;
        Destroy(gameObject);
    }

}
