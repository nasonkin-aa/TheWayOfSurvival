using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    protected int maxHealth = 100;
    [SerializeField]
    private int _health;
    public UnityEvent<int> OnHpChange;

    private void Awake()
    {
        _health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;
        OnHpChange.Invoke(_health);

        if (_health <= 0) 
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
   
}
