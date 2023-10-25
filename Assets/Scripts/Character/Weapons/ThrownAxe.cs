using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownAxe : MonoBehaviour
{
    public Action OnAxeCollision;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnAxeCollision();
        Debug.Log("11111");
    }
}
