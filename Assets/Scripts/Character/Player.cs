using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    [SerializeField] private Health health;
    
    private List<ModifierPrepare> _modifiers = new();
    public static Player GetPlayer { get; private set; }   
    public static Transform PlayerTransform { get; private set; }

    public static event Action ShakeEvent;
    public event Action SoulPickUpEvent;
    
    public virtual void Awake()
    {
        health ??= GetComponent<Health>();
        GetPlayer = this;
        PlayerTransform = transform;
    }

    private void OnEnable()
    {
        health.DamageEvent += OnDamage;
        health.DieEvent += OnDie;
    }

    private void OnDisable()
    {
        health.DamageEvent -= OnDamage;
        health.DieEvent -= OnDie;
    }

    private void OnDamage(int value)
    {
        SoundManager.instance.PlaySound("PlayerDamage");
        ShakeEvent?.Invoke();
    }

    private void OnDie()
    {
        GlobalScore.GameFinished();
        SceneManagerSelect.SelectSceneByName("GameOver");
    }
    

    public Weapon GetWeapon()
    {
        return GetComponentInChildren<Weapon>();
    }

    public Health GetHealth()
    {
        return GetComponent<Health>();
    }

    public void AddModifier(ModifierPrepare modifier)
    {
        ModifierPrepare containedMod = _modifiers
            .Find(mod => mod.GetModifierInfo().GetModifierType == modifier.GetModifierInfo().GetModifierType);

        if (containedMod is null)
        {
            modifier?.CreateSubObject(transform);
            _modifiers.Add(modifier);
        }
        else
        {
            containedMod.SetModifierInfo(modifier.GetModifierInfo());
            modifier?.SetModifierInfo(modifier.GetModifierInfo(), transform);
        }
    }

    public void OnSoulPickUp()
    {
        SoulPickUpEvent?.Invoke();
    }

    private void OnDestroy()
    {
        GetPlayer = null;
    }
}
