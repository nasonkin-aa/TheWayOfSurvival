using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerSelect : MonoBehaviour
{
    public void SelectSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
