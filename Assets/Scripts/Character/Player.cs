using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthBase))]
public class Player : MonoBehaviour
{
    protected List<ModifierPrepare> _modifiers = new();
    public static Player GetPlayer { get; private set; }   
    public static Transform PlayerTransform { get; private set; }
    
    public virtual void Awake()
    {
        PlayerTransform = transform;
        GetPlayer = this;
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

    private void OnDestroy()
    {
        GetPlayer = null;
    }
}
