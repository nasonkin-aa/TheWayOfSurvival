using System;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth = 100;

    [SerializeField]
    private int _health = 1;
    public Action<int> OnHpChange;

    protected void Awake() 
    {
        _health = MaxHealth;
    }

    public int MaxHealth { 
        get { return _maxHealth; } 
        set { _maxHealth = value; } 
    }  
    public virtual int Health {
        get { return _health; }
        set {
            OnHpChange?.Invoke(value - _health);
            _health = value;

            if (_health <= 0)
            {
                _health = 0;
                Die();
                return;
            }

            //if (_health > MaxHealth)
            //    _health = MaxHealth;


        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
    }
}
