using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public static bool IsPayerOnTheGround { get; private set; }
    private Collider2D _groundCollider;
    private ContactFilter2D _contactFilter;
    private Animator AnimatorPlayer => gameObject.GetComponentInParent<Animator>();
    private readonly LayerMask _jumpingMask = (1 << 10) | (1 << 8); // Mask include Ground(10) and Building(8)

    private void Awake()
    {
        _contactFilter = new ContactFilter2D().NoFilter();
        _contactFilter.useLayerMask = true;
        _contactFilter.layerMask = _jumpingMask;
        _groundCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        List<Collider2D> list = new ();
        if (_groundCollider.OverlapCollider(_contactFilter, list) > 0)
        {
            IsPayerOnTheGround = true;
            AnimatorPlayer.SetBool("IsJumping", false);
        }
        else
        {
            IsPayerOnTheGround = false;
            AnimatorPlayer.SetBool("IsJumping", true);
        }
            
    }
}
