using System;
using UnityEngine.SceneManagement;
namespace UnityEngine
{
    public class PlayerHealth : HealthBase
    {
        public static Action OnShake;
        public override void Die()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public override void TakeDamage(int amount)
        {
            Health -= amount;
            OnShake?.Invoke();
        }

    }
}
