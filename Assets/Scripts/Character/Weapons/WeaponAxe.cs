using UnityEngine;

public class WeaponAxe : RangeWeapon
{
    protected float _AxeTorque = -30f;
    public override void Awake()
    {
        base.Awake();
        SetDamageWeapon(WeaponDamage);
        SelectRangeWeapon(WeaponType.Axe);
    }

    protected override void AddForceForProjectile(Rigidbody2D rb, Vector3 direction, int force)
    {
        base.AddForceForProjectile (rb, direction, force);
        var sign = Mathf.Sign(Player.GetPlayer.transform.localScale.x);

        rb.AddTorque(sign * _AxeTorque);

        var newLocalScale = rb.transform.localScale;
        newLocalScale.x = sign * rb.transform.localScale.x;
        rb.transform.localScale = newLocalScale;
    }
}
