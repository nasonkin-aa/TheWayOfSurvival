using UnityEngine;

public class PauseState : MonoBehaviour
{
    public GameObject pauseMenu;

    private void OnEnable()
    {
        PauseSystem.ToggleEvent += OnToggle;
    }

    private void OnDisable()
    {
        PauseSystem.ToggleEvent -= OnToggle;
    }

    public void OnToggle(bool isPaused) => pauseMenu.SetActive(isPaused);
}