using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class AttackZone : MonoBehaviour
{
    public ContactFilter2D contactFilter2D;

    private CircleCollider2D _circleCollider2D;
    private Health _targetHealth;

    private void Start()
    {
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _circleCollider2D.radius = Random.Range( _circleCollider2D.radius, _circleCollider2D.radius * 2f);
    }

    private void Update()
    {
        var collider2Ds = new List<Collider2D>();
        var countOverlapCollider = _circleCollider2D.OverlapCollider(contactFilter2D, collider2Ds);

        if (countOverlapCollider > 0)
        {
            gameObject.GetComponentInParent<Animator>().SetBool("TargetInZone", true);
            _targetHealth = collider2Ds[0].gameObject.GetComponent<Health>();
            transform.parent.gameObject.GetComponent<Move>().enabled = false;
        }
        else
        {
            gameObject.GetComponentInParent<Animator>().SetBool("TargetInZone", false);
            transform.parent.gameObject.GetComponent<Move>().enabled = true;
        }
    }

    public void AttackTarget(int value) //Used by Animator Attack
    {
        if(_targetHealth != null)
            _targetHealth.TakeDamage(value);
    }
}