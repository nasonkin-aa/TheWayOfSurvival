using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class GroundChecker : MonoBehaviour
{
    public static bool IsPayerOnTheGround { get; private set; }
    private Collider2D _groundCollider;
    private ContactFilter2D _contactFilter;

    private void Awake()
    {
        _contactFilter = new ContactFilter2D().NoFilter();
        _contactFilter.useLayerMask = true;
        
        _contactFilter.layerMask = LayerMask.GetMask("Player");
        _groundCollider = GetComponent<Collider2D>();
        Debug.Log(_contactFilter.layerMask);
    }

    private void Update()
    {
        List<Collider2D> list = new List<Collider2D>();

        if (_groundCollider.OverlapCollider(_contactFilter, list) >= 2)
            IsPayerOnTheGround = true;
        else
            IsPayerOnTheGround = false;
    }

    // public void OnTriggerStay2D(Collider2D other)
    // {
    //     if (other != null)
    //     {
    //         IsPayerOnTheGround = true;
    //     }
    // }
}
