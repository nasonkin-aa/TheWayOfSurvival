using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class LightWorld : MonoBehaviour
{
    [SerializeField] private Gradient gradient;
    public float duration;
    private Light2D _light;
    private float _startTime;
    public static Action OnNightStart;

    private bool _nightStarted = false;

    private void Awake()
    {
        _light = GetComponent<Light2D>();
        _startTime = Time.time;
    }

    private void Update()
    {
        var time = Time.time - _startTime;

        var percent = (Mathf.Sin(time / duration * Mathf.PI) * 0.5f + 0.5f);

        percent = Mathf.Clamp01(percent);
        _light.color = gradient.Evaluate(percent);

        //Debug.Log(percent + "  " + time);

        CheckNight(time);
    }

    private void CheckNight(float currentTime)
    {
        if ((int) (currentTime % duration)  == (int) duration / 2 && !_nightStarted)
        {
            OnNightStart?.Invoke();
            _nightStarted = true;
        }
        
        if ((int) (currentTime % duration) == 0 && _nightStarted)
        {
            _nightStarted = false;
        }
        
    }
}