using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Player : Singleton<Player>
{
    [SerializeField] private Health health;
    [SerializeField] private Weapon weapon;

    private readonly List<ModifierPrepare> _modifiers = new();

    public Health Health => health;
    public Weapon Weapon => weapon;

    public event Action ShakeEvent;

    protected override void Awake()
    {
        base.Awake();
        
        gameObject.AssignComponentIfUnityNull(ref health);
        gameObject.AssignComponentInChildrenIfUnityNull(ref weapon);
    }

    private void OnEnable()
    {
        health.DamageEvent += OnDamage;
        health.DeathEvent += OnDeath;
    }

    private void OnDisable()
    {
        health.DamageEvent -= OnDamage;
        health.DeathEvent -= OnDeath;
    }

    private void OnDamage(int value)
    {
        SoundManager.Instance.PlaySound("PlayerDamage");
        ShakeEvent?.Invoke();
    }

    private void OnDeath()
    {
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
}
