using UnityEngine;

public class PauseState : MonoBehaviour
{
    public GameObject pauseMenu;

    private static PauseState instance;

    private void Awake()
    {
        instance = this;
    }

    public static PauseState Instance
    {
        get { return instance; }
    }

    public void TogglePauseMenu()
    {
        if (pauseMenu is null)
            Debug.LogError("No pauseMenu GameObject in PauseState");
        else
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
    }
}