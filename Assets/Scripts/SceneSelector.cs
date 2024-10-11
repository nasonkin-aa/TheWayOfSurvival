using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    public void SelectGame() => SceneManager.LoadScene("Game");
    public void SelectTutorial() => SceneManager.LoadScene("Tutorial");
}
