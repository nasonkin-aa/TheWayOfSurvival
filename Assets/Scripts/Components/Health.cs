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
    public static Action<int> OnHpChange;
    public GameObject g;

    private void Awake()
    {
        _health = maxHealth;
        g = new GameObject("test1121");
        TakeDamage(0); // Reset HP UI for default value
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;
        
        OnHpChange?.Invoke(_health);

        if (_health <= 0) 
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
   
}
