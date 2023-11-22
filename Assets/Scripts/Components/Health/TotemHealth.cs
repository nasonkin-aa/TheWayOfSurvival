using UnityEngine.SceneManagement;
namespace UnityEngine
{
    public class TotemHealth : HealthBase
    {
        public override void Die()
        {
            SceneManager.LoadScene("Menu");            
        }
        
        public override void TakeDamage(int amount)
        {
            SoundManager.instance.PlaySound("TotemDamage");
            base.TakeDamage(amount);
        }
    }
}



