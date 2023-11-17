public class Health : HealthBase
{
    public override void Die()
    {
        Soul.SpawnSoul(transform.position);
        base.Die();
    }
    
}
