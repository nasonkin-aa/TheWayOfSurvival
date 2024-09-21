using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private bool _isOpened;

    private void OnEnable()
    {
        PlayerInput.Instance.PausePressedEvent += OnPausePressed;
    }

    private void OnDisable()
    {
        PlayerInput.Instance.PausePressedEvent -= OnPausePressed;
    }

    private void OnPausePressed()
    {
        _isOpened = !_isOpened;
        pauseMenu.SetActive(_isOpened);

        if (_isOpened) PauseSystem.Pause(this);
        else PauseSystem.Unpause(this);
    }
}