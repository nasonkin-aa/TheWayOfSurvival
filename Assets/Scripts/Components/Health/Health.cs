public class Health : HealthBase
{
    public override void Die()
    {
        Soul.SpawnSoul(transform.position);
        base.Die();
    }

    public override void TakeDamage(int amount)
    {
        SoundManager.instance.PlaySound(gameObject.GetComponent<EnemyType>().name + "Damage");
        base.TakeDamage(amount);
    }
    
}
