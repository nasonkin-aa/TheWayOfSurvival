using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class LightWorld : MonoBehaviour
{
    [SerializeField] private Gradient gradient;
    public static float duration;
    private Light2D _light;
    private static float _startTime;
    public static event Action NightStartEvent;
    public static event Action DayStartEvent;

    private bool _nightStarted = false;

    private void Awake()
    {
        _light = GetComponent<Light2D>();
        _startTime = Time.time;

    }

    private void Update()
    {
        var time = Time.time - _startTime;

        var percent = Mathf.Sin(time / duration * Mathf.PI) * 0.5f + 0.5f;

        percent = Mathf.Clamp01(percent);
        _light.color = gradient.Evaluate(percent);

        //Debug.Log(percent + "  " + time);

        CheckDayNight(time);
    }

    private void CheckDayNight(float currentTime)
    {
        if ((int) (currentTime % duration)  > (int) (duration / 3f) && !_nightStarted)
        {
            NightStartEvent?.Invoke();
            _nightStarted = true;
        }
        
        if ((int) (currentTime % duration) < 0.01f && _nightStarted)
        {
            DayStartEvent?.Invoke();
            _nightStarted = false;
        }
    }

    public static void SetNewDuration(float curDuration)
    {
        duration = curDuration;
        _startTime = Time.time;
    }
}