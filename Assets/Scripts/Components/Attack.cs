using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public static Action<int> OnAttackZone;
    public int damage = 10;
    public void AttackZoneTarget() //Used animator attack
    {
        OnAttackZone(damage);
    }
}
