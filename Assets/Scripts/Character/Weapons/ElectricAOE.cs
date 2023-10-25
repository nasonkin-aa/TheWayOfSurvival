using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricAOE : MonoBehaviour, IWeaponModifier
{
    private Collider2D _AOECollider;
    public int AOEDamage = 20;
    private void Awake()
    {
        _AOECollider = GetComponent<Collider2D>();
    }
    public void ActivateEffect()
    {
        List<Health> unitsWithHealth = new (_AOECollider.GetComponents<Health>());
        unitsWithHealth.ForEach(e => e.TakeDamage(AOEDamage));
    }
    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
}
