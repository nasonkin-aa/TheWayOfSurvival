using System;
using System.Collections.Generic;
using UnityEngine;

public static class PauseSystem
{
    private const float PauseTimeScale = 0;

    private static float _gameTimeScale;
    private static bool _isPaused;

    private static readonly HashSet<int> _pauseSources = new();

    public static event Action PauseEvent;
    public static event Action UnpauseEvent;
    public static Action<bool> ToggleEvent;

    public static void Pause(object source = null)
    {
        _pauseSources.Add(source == null ? 0 : source.GetHashCode());

        if (_isPaused) return;

        _isPaused = true;

        _gameTimeScale = Time.timeScale;
        Time.timeScale = PauseTimeScale;

        PauseEvent?.Invoke();
    }

    public static void Unpause(object source = null)
    {
        if (!_isPaused) return;

        _pauseSources.Remove(source == null ? 0 : source.GetHashCode());

        if (_pauseSources.Count > 0) return;

        _isPaused = false;

        Time.timeScale = 1;

        UnpauseEvent?.Invoke();
    }

    public static void Toggle(object source = null)
    {
        if (_isPaused) Unpause(source);
        else Pause(source);

        ToggleEvent?.Invoke(_isPaused);
    }
}
