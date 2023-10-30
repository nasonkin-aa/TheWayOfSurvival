using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : Weapon
{
    public enum WeaponType
    {
        Axe,
        Arrow,
        NotExistWeapon
    }
    

    protected GameObject _projectilePrefab;
    [SerializeField]
    protected int _projectileForce = 1000;
    public void SelectRangeWeapon(WeaponType weapon)
    {
        _projectilePrefab = Resources.Load("Weapons/" + weapon) as GameObject;
        if (_projectilePrefab == null)
        {
            Debug.LogError($"Selected RangeWeapon for Player with name: '{weapon}' not exist");
        }
    }

    public override void Attack(Vector3 direction, Vector3 attackPoint)
    {
        base.Attack(direction, attackPoint);
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
        var newProjectile = Instantiate(_projectilePrefab, attackPoint, rotation);
        Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
        _modifiers.ForEach(mod => mod.CreateSubObject(newProjectile.transform));
        rb.AddForce(direction * _projectileForce);
        rb.AddTorque(-30f);
    }
}
