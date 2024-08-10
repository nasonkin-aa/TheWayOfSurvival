using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class FairyAttack : Attack
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private float speedProjectile;
    private void Awake()
    {
        _projectile ??= Resources.Load("Weapons/Knife1") as GameObject;
    }
    public override void Start()
    {
        _attackZone = GetComponentInChildren<AttackZone>();
        _attackZone.OnCollisionWithTarget += ContactWithTarget;
    }
    public override void ContactWithTarget(Health health)
    {
        if (health is null) return;
        
        base.ContactWithTarget(health);
    }

    public void Attack ()
    {

        Vector2 direction = _targetToAttack.transform.position - transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        var obj = Instantiate(_projectile, transform.position, rotation);
        obj.GetComponent<EnemyProjectiles>().Damage = Damage;
        AudioManager.Instance.Play("FairyProjectile");
        
        obj.GetComponent<Rigidbody2D>().velocity = direction * speedProjectile;
        GetComponent<Rigidbody2D>().AddForce(-direction * 0.2f);
    }

    public bool CheckTargetToAttack(Health health)
    {
        var fairyAttackZone = _attackZone as FairyAttackZone;
        var target = fairyAttackZone.CheckTargetInCollider(health);
        if (target is not null && target == health)
            return true;
        return false;
    }
}
