using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    public static Player GetPlayer { get; private set; }
    protected List<ModifierPrepare> _modifiers = new();
    public virtual void Awake()
    {
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
        Debug.Log(containedMod);

        if (containedMod is null)
        {
            modifier?.CreateSubObject(transform);
            _modifiers.Add(modifier);
        }
        else
        {
            Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            containedMod.SetModifierInfo(modifier.GetModifierInfo());
            modifier?.SetModifierInfo(modifier.GetModifierInfo(), transform);
        }
    }

    private void OnDestroy()
    {
        GetPlayer = null;
    }
}
