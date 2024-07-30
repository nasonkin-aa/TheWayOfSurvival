using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthBase))]
public class Player : MonoBehaviour
{
    protected List<ModifierPrepare> _modifiers = new();
    public static Player GetPlayer { get; private set; }   
    public static Transform PlayerTransform { get; private set; }

    public event Action SoulPickUp;
    
    public virtual void Awake()
    {
        GetPlayer = this;
        PlayerTransform = transform;
    }
    public Weapon GetWeapon()
    {
        return GetComponentInChildren<Weapon>();
    }

    public HealthBase GetHealth()
    {
        return GetComponent<HealthBase>();
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
        SoulPickUp?.Invoke();
    }

    private void OnDestroy()
    {
        GetPlayer = null;
    }
}
