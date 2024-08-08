using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth = 100;
    
    public event Action<int> ChangeEvent;
    public event Action DeathEvent;

    public event Action<int> DamageEvent;
    public event Action<int> HealEvent;

    private void Awake() => CurrentHealth = MaxHealth;

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

            currentHealth = maxHealth.AtMost(value);

            ChangeEvent?.Invoke(delta);

            if (value <= 0)
            {
                currentHealth = 0;
                DeathEvent?.Invoke();
                return;
            }

        }
    }

    public void Scale(float scale) => MaxHealth = (int)(MaxHealth * scale);

    public void TakeDamage(int amount)
    {
        DamageEvent?.Invoke(amount);
        CurrentHealth -= amount;
    }

    public void Heal(int amount)
    {
        HealEvent?.Invoke(amount);
        CurrentHealth += amount;
    }
}
