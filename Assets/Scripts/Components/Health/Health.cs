using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth = 100;
    
    public event Action<int> ChangeEvent;
    public event Action DieEvent;

    public event Action<int> DamageEvent;
    public event Action<int> HealEvent;

    protected void Awake() 
    {
        currentHealth = MaxHealth;
    }
    
    public float Percentage => CurrentHealth.DivideBy(maxHealth);

    public int MaxHealth 
    { 
        get => maxHealth;
        set 
        { 
            var healthPercent = currentHealth.DivideBy(maxHealth);
            
            maxHealth = value;
            CurrentHealth = currentHealth >= maxHealth ? maxHealth : (int)(maxHealth * healthPercent);
        } 
    }  
    
    public int CurrentHealth 
    {
        get => currentHealth;
        set
        {
            int delta = value - currentHealth;
            ChangeEvent?.Invoke(delta);

            if (delta < 0)
                DamageEvent?.Invoke(delta);
            else
                HealEvent?.Invoke(delta);

            if (value <= 0)
            {
                currentHealth = 0;
                DieEvent?.Invoke();
                return;
            }

            currentHealth = maxHealth.AtMost(value);
        }
    }

    public void ScaleHealth(float scale)
    {
        MaxHealth = (int) (maxHealth * scale);
        currentHealth = MaxHealth;
    }

    public void TakeDamage(int amount) => CurrentHealth -= amount;
    public void Heal(int amount) => CurrentHealth += amount;
}
