using System.Collections;
using UnityEngine;

public class VannAttack : Attack
{
    [SerializeField] protected GameObject _projectilePrefab;
    [SerializeField] protected float launchAngle = 45f;
    protected bool _isReadyToAttack = true;
    protected float _reloadTime = 5f;
    [SerializeField] protected Transform _SpawnPoint;
    [SerializeField] protected float _firePower = 20f;

    public override void ContactWithTarget(HealthBase health)
    {
        if (!_isReadyToAttack)
            return;

        _targetToAttack = health;
        OnAttackReady?.Invoke();
        _isReadyToAttack = false;
        StartCoroutine(Reload());
    }

    void FireProjectile(Transform target)
    {
        Vector2 direction = _targetToAttack.transform.position - transform.position;
        var directionSign = Mathf.Sign(direction.x);

        GameObject projectile = Instantiate(_projectilePrefab, _SpawnPoint.position, Quaternion.identity);
        
        projectile.GetComponent<EnemyProjectiles>().Damage = damage;
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        var yDistance = (target.position.y - transform.position.y) * directionSign;
        if (Mathf.Abs(yDistance) < 2)
            yDistance = 0;

        var distance = Mathf.Abs((target.position.x - transform.position.x) / 2 + yDistance); // until target
        var vx = Mathf.Sqrt(distance * (-Physics2D.gravity.y) / 2); // x velicity for flying distance
        var power = vx / Mathf.Cos(45);

        rb.velocity = new Vector2(directionSign, 1).normalized * (power); // 45 degry (vector) * magnitude
    }

    public void Attack ()
    {
        FireProjectile(_targetToAttack.transform);
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(_reloadTime);
        _isReadyToAttack = true;
    }
}
