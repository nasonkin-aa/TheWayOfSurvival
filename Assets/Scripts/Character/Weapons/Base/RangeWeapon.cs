using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RangeWeapon : Weapon
{
    protected enum WeaponType
    {
        Axe,
        Arrow,
        NotExistWeapon
    }
    
    private GameObject _projectilePrefab;
    [SerializeField]
    protected int projectileForce = 1000;

    protected void SelectRangeWeapon(WeaponType weapon)
    {
        _projectilePrefab = Resources.Load("Weapons/" + weapon) as GameObject;
        if (_projectilePrefab == null)
        {
            Debug.LogError($"Selected RangeWeapon for Player with name: '{weapon}' not exist");
        }
    }

    public override void Attack(Vector3 direction, Vector3 attackPoint)
    {
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
        var newProjectile = Instantiate(_projectilePrefab, attackPoint, rotation);
        Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
        _modifiers.ForEach(mod => mod.CreateSubObject(newProjectile.transform));
        rb.AddForce(direction * projectileForce);
        rb.AddTorque(-30f);
        newProjectile.GetComponent<Projectile>().Damage = WeaponDamage; 
    }
}
