using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class AttackZone : MonoBehaviour
{
    private Health _targetHealth;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            gameObject.GetComponentInParent<Animator>().SetBool("TargetInZone", true);
            _targetHealth = other.gameObject.GetComponent<Health>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            gameObject.GetComponentInParent<Animator>().SetBool("TargetInZone", false);
        }
    }
    public void AttackTarget(int value)
    {
        if(_targetHealth != null)
            _targetHealth.TakeDamage(value);
    }
}