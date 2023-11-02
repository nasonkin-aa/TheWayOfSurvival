using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private AttackZone _attackZone;
    public int damage = 10;
    private void Start()
    {
        _attackZone = gameObject.transform.GetComponentInChildren<AttackZone>();
        if (_attackZone == null)
        {
            Debug.LogError("Not found AttackZone: "+ gameObject.name);
        }
    }

    public void AttackZoneTarget()
    {
        _attackZone.AttackTarget(damage);
    }
}
