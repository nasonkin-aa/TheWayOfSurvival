using UnityEngine.SceneManagement;
namespace UnityEngine
{
    public class TotemHealth : HealthBase
    {
        public override void Die()
        {
            SceneManager.LoadScene(SceneManager.sceneCount - 1);            
        }
    }
}



