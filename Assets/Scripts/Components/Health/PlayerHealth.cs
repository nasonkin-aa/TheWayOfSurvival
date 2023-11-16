using UnityEngine.SceneManagement;
namespace UnityEngine
{
    public class PlayerHealth : HealthBase
    {
        protected override void Die()
        {
            SceneManager.LoadScene(SceneManager.sceneCount - 1);
        }
    }
}
