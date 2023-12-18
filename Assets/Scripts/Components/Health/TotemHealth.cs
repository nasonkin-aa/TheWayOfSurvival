namespace UnityEngine
{
    public class TotemHealth : HealthBase
    {
        public override void Die()
        {
            GlobalScore.GameFinished();
            SceneManagerSelect.SelectSceneByName("GameOver");
        }
        
        public override void TakeDamage(int amount)
        {
            SoundManager.instance.PlaySound("TotemDamage");
            base.TakeDamage(amount);
        }
    }
}



