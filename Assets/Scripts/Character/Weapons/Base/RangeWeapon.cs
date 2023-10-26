using UnityEngine;

public class RangeWeapon : Weapon
{
    protected GameObject _projectilePrefab;
    [SerializeField] protected string _projectileName;
    [SerializeField] protected int _projectileForce = 1000;

    public virtual void Awake()
    {
        _projectilePrefab = GameObject.Find(_projectileName);
    }

    public override void Attack(Vector3 direction, Vector3 atackPoint)
    {
        base.Attack(direction, atackPoint);
        var newProjectile = Instantiate(_projectilePrefab, atackPoint, Quaternion.identity);
        _modifiers.ForEach(mod => mod.CreateSubObject(newProjectile.transform));

        newProjectile.GetComponent<Rigidbody2D>().AddForce(direction * _projectileForce);
    }
}
