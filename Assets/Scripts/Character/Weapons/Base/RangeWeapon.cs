using UnityEngine;

public class RangeWeapon : Weapon
{
    protected enum WeaponType
    {
        Axe,
        Arrow,
        NotExistWeapon
    }
    
    protected GameObject _projectilePrefab;
    [SerializeField]
    protected int projectileForce = 1000;

    public override void Awake()
    {
        base.Awake();
    }
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
        var newProjectile = CreateProjectile(direction, attackPoint);

        Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
        AddForceForProjectile(rb, direction, projectileForce);

        _modifiers.ForEach(mod => mod.CreateSubObject(newProjectile.transform));
    }

    protected virtual GameObject CreateProjectile(Vector3 direction, Vector3 attackPoint)
    {
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
        var newProjectile = Instantiate(_projectilePrefab, attackPoint, rotation);

        var projectileDamage = newProjectile.GetComponent<Projectile>();
        if (projectileDamage is not null)
            newProjectile.GetComponent<Projectile>().Damage = WeaponDamage;

        return newProjectile;
    }

    protected virtual void AddForceForProjectile(Rigidbody2D rb, Vector3 direction, int force)
    {
        rb.AddForce(direction * projectileForce);
    }
}
