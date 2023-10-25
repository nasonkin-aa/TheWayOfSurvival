using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Camera _mainCamera;

    public IAttackable Weapon;

    private GameObject _spawnPoint;
    private Vector3 _position => transform.position;

    private void Attack( Vector3 mousPosition)
    {
        Vector3 mouseWorldPosition = ConvectoMousePosition(mousPosition);
        Vector3 attackDirection = (mouseWorldPosition - _position).normalized;
        Weapon.Attack(attackDirection, _position);
    }
       
    private void Awake()
    {
        _mainCamera = Camera.main;
        Weapon = new WeaponAxe();   
    }

    private Vector3 ConvectoMousePosition(Vector3 position)
    {
        Vector3 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(position);
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }
    public void OnEnable()
    {
        PlayerInput.OnPlayerAttack += Attack;
    }
    public void OnDisable()
    {   
        PlayerInput.OnPlayerAttack -= Attack;
    }
    
}
