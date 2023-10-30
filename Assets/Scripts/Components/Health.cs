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

    private void Awake()
    {
        _health = maxHealth;
        
    }

    private void Start()
    {
        TakeDamage(0); // Reset HP UI for default value
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;
        
        //Check when damage Player, send health in UI
        if (gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            OnHpChange?.Invoke(_health);
        }
        
        if (_health <= 0) 
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
   
}
