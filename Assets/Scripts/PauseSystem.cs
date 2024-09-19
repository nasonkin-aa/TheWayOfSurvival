using System;
using UnityEngine;

public static class PauseSystem
{
    private const float PauseTimeScale = 0;

    private static float _gameTimeScale;
    private static bool _isPaused;

    public static event Action PauseEvent;
    public static event Action UnpauseEvent;
    public static Action<bool> ToggleEvent;

    public static void Pause()
    {
        if (_isPaused) return;

        _isPaused = true;

        _gameTimeScale = Time.timeScale;
        Time.timeScale = PauseTimeScale;

        PauseEvent?.Invoke();
    }

    public static void Unpause()
    {
        if (!_isPaused) return;

        _isPaused = false;

        Time.timeScale = _gameTimeScale;

        UnpauseEvent?.Invoke();
    }

    public static void Toggle()
    {
        if (_isPaused) Unpause();
        else Pause();

        ToggleEvent?.Invoke(_isPaused);
    }
}
