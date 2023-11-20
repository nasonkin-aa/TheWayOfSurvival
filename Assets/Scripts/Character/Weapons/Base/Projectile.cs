using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected internal int Damage;
    protected bool _isContact = false;
    public Action OnProjectileCollision;
    public static ContactFilter2D ContactWithEnemies = PrepareFilter(); // Contact only with Enemy

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isContact) return; //Hack for kill 1 enemy 1 projectile
        
        collision.gameObject.GetComponent<Health>()?.TakeDamage(Damage);

        OnProjectileCollision?.Invoke();
        _isContact = true;
        Destroy(gameObject);
    }

    public static ContactFilter2D PrepareFilter()
    {
        var filter = new ContactFilter2D
        {
            useLayerMask = true,
            layerMask = (1 << 9) // LayerMask with Enemy
        };
        return filter;
    }

}
