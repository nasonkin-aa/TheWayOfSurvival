using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    protected int maxHealth = 100;
    [SerializeField]
    private int _health;

    private void Awake()
    {
        _health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;
            if (_health <= 0) 
                Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
   
}
