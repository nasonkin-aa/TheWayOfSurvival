using System;

namespace UnityEngine
{
    public class PlayerHealth : HealthBase
    {
        public static Action OnShake;
        public override void Die()
        {
            GlobalScore.GameFinished();
            SceneManagerSelect.SelectSceneByName("GameOver");
        }

        public override void TakeDamage(int amount)
        {
            base.TakeDamage(amount);
            OnShake?.Invoke();
            SoundManager.instance.PlaySound("PlayerDamage");
        }   
    }
}
