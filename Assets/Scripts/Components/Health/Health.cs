using System;
using UnityEngine;

public class Health : HealthBase
{
    protected override void Die()
    {
        Soul.SpawnSoul(transform.position);
        base.Die();
    }
    
}
