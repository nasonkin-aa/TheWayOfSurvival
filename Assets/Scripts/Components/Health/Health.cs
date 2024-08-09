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
            var percentage = Percentage;
            
            maxHealth = value;
            CurrentHealth = currentHealth >= maxHealth ? maxHealth : (int)(maxHealth * percentage);
        } 
    }  
    
    public int CurrentHealth 
    {
        get => currentHealth;
        set
        {
            int newValue = value.AtMost(maxHealth);
            int delta = newValue - currentHealth;
            currentHealth = newValue;
            
            ChangeEvent?.Invoke(delta);

            if (value <= 0)
            {
                currentHealth = 0;
                DeathEvent?.Invoke();
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
