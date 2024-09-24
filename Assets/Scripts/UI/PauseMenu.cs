using System;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private PlayerInput _playerInput;

    private bool _isOpened;

    /*public void Start()
    {
        _playerInput = FindObjectOfType<PlayerInput>();
    }*/

    private void OnEnable()
    {
        _playerInput.PausePressedEvent += OnPausePressed;
    }

    private void OnDisable()
    {
        _playerInput.PausePressedEvent -= OnPausePressed;
    }

    private void OnPausePressed()
    {
        _isOpened = !_isOpened;
        pauseMenu.SetActive(_isOpened);

        if (_isOpened) PauseSystem.Pause(this);
        else PauseSystem.Unpause(this);
    }
}