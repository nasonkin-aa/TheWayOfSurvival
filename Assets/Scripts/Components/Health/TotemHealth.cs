using UnityEngine.SceneManagement;
namespace UnityEngine
{
    public class TotemHealth : HealthBase
    {
        protected override void Die()
        {
            SceneManager.LoadScene(SceneManager.sceneCount - 1);            
        }
    }
}



