using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public static bool IsPayerOnTheGround { get; private set; }
    private Collider2D _groundCollider;
    private ContactFilter2D _contactFilter;

    private void Awake()
    {
        _contactFilter = new ContactFilter2D().NoFilter();
        _contactFilter.useLayerMask = true;
        
        _contactFilter.layerMask = ~LayerMask.GetMask("Player");
        _groundCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        List<Collider2D> list = new List<Collider2D>();
        if (_groundCollider.OverlapCollider(_contactFilter, list) > 0)
            IsPayerOnTheGround = true;
        else
            IsPayerOnTheGround = false;
    }
}
