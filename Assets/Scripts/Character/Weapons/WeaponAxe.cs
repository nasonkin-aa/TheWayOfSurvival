using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponAxe : MonoBehaviour, IAttackable
{
    [SerializeField] private GameObject Axe;
    public Action OnPlayerJump;
    public List<IWeaponModifier> modifiers = new List<IWeaponModifier>();   

    public WeaponAxe()
    {
        var mod = new ElectricAOE();
        modifiers.Add(mod);
        Axe = GameObject.Find("Axe");
    }
    
    public void Attack(Vector3 direction, Vector3 point)
    {
        var NewAxe = Instantiate(Axe, point, Quaternion.identity);
        var sub = ElectricAOE.CreateSubObject(NewAxe.transform);
        

        //sub.transform.SetParent(NewAxe.transform);

        NewAxe.GetComponent<ThrownAxe>().OnAxeCollision += NewAxe.GetComponentInChildren<ElectricAOE>().ActivateEffect;

        NewAxe.GetComponent<Rigidbody2D>().AddForce(direction * 1000);
    }

    public void Attack(Vector3 direction)
    {
        throw new System.NotImplementedException();
    }
}
