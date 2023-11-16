using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class LightWorld : MonoBehaviour
{
    [SerializeField] private Gradient _gradient;
    public float duration;
    private Light2D _light;
    private float _startTime;


    private void Awake()
    {
        _light = GetComponent<Light2D>();
        _startTime = Time.time;
    }

    private void Update()
    {
        var time = Time.time - _startTime;
        var percent = Mathf.Sin(time / duration * Mathf.PI * 2) * 0.5f +0.5f;
        percent = Mathf.Clamp01(percent);
        _light.color = _gradient.Evaluate(percent);
    }
}
