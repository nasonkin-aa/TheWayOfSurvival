using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAxe : MonoBehaviour, IAttackable
{
    [SerializeField] private GameObject Axe;

    public WeaponAxe()
    {
        Axe = Instantiate(GameObject.Find("Axe"));
    }
    
    public void Attack(Vector3 direction, Vector3 point)
    {
        var NewAxe = Instantiate(Axe, point, Quaternion.identity);
        NewAxe.GetComponent<Rigidbody2D>().AddForce(direction * 1000);
    }

    public void Attack(Vector3 direction)
    {
        throw new System.NotImplementedException();
    }
}
