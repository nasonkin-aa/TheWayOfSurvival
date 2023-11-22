using UnityEngine;

public class Health : HealthBase
{
    [SerializeField] protected int _exp = 50;
    public override void Die()
    {
        GlobalScore.Instance?.AddPoints(_exp / 2);
        PrepareSoul();
        base.Die();
    }

    public override void TakeDamage(int amount)
    {
        SoundManager.instance.PlaySound("HitSound");
        base.TakeDamage(amount);
    }

    protected void PrepareSoul()
    {
        var soul = Soul.SpawnSoul(transform.position);
        soul.SetExp(_exp);
    }   
}
