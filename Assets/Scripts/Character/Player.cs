using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    public static Player GetPlayer { get; private set; }
    protected List<ModifierPrepare> _modifiers = new();
    public static Transform PlayerTransform { get; set; }
    
    public virtual void Awake()
    {
        PlayerTransform = transform;
        GetPlayer = this;
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

    private void OnDestroy()
    {
        GetPlayer = null;
    }
}
