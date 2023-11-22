using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerSelect : MonoBehaviour
{
    public static void SelectSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        PlayerInput.UnPause();
    }

    public static void Exitgame()
    {
        Application.Quit();
    }
}
