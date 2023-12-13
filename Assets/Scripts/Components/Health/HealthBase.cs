using System;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth = 100;

    [SerializeField]
    private int _health = 100;
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
            if (value <= 0)
            {
                _health = 0;
                Die();
                return;
            }
            
            _health = value;
        }
    }

    public void ScaleHealth(float scale)
    {
        MaxHealth = (int) (_maxHealth * scale);
        _health = MaxHealth;
    }
    public float GetHpInPercents() => (float)Health / MaxHealth;
    public virtual void Die() => Destroy(gameObject);
    public virtual void TakeDamage(int amount) => Health -= amount;

    public virtual void GetHeal(int amount)
    {
        if (Health + amount >= _maxHealth)
            Health += _maxHealth - Health + amount;
        else
            Health += amount;
    }

}
