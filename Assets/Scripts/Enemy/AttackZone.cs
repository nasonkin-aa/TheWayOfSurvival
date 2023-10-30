using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class AttackZone : MonoBehaviour
{
    protected Health _targetHealth;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>() != null || (other.gameObject.GetComponent<Health>() is not null && other.gameObject.layer == LayerMask.NameToLayer("Building")))
        {
            gameObject.GetComponentInParent<Animator>().SetBool("TargetInZone", true);
            _targetHealth = other.gameObject.GetComponent<Health>();
            Debug.Log("enter");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>() != null || (other.gameObject.GetComponent<Health>() is not null && other.gameObject.layer == LayerMask.NameToLayer("Building")))
        {
            gameObject.GetComponentInParent<Animator>().SetBool("TargetInZone", false);
            Debug.Log("Exit");
        }
    }

    public void AttackTarget(int value) //Used by Animator Attack
    {
        if(_targetHealth != null)
            _targetHealth.TakeDamage(value);
    }
}