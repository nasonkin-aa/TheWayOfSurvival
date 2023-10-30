using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private AttackZone _attackZone;
    private void Awake()
    {
        _attackZone = gameObject.transform.GetComponentInChildren<AttackZone>();
        if (_attackZone == null)
        {
            Debug.LogError("Not found AttackZone: "+ gameObject.name);
        }
    }
}
