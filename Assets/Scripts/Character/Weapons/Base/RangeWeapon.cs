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

    public override void Attack(Vector3 direction, Vector3 atackPoint)
    {
        base.Attack(direction, atackPoint);
        var newProjectile = Instantiate(_projectilePrefab, atackPoint, Quaternion.identity);
        _modifiers.ForEach(mod => mod.CreateSubObject(newProjectile.transform));

        newProjectile.GetComponent<Rigidbody2D>().AddForce(direction * _projectileForce);
    }
}
