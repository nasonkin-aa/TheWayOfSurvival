using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera _cinemahineCamera;
    private CinemachineBasicMultiChannelPerlin _cameraModule;
    private float _shakeTimer;
    private float _shakeTimerTotal;
    private float _startingIntensity;

    [SerializeField] private float intensity;
    [SerializeField] private float time;
    private void Awake()
    {
        _cinemahineCamera = GetComponent<CinemachineVirtualCamera>();
        _cameraModule = _cinemahineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cameraModule.m_AmplitudeGain = 0;
    }

    private void OnShake()
    {
        _cameraModule.m_AmplitudeGain = intensity;
        _startingIntensity = intensity;
        _shakeTimerTotal = time;
        _shakeTimer = time;
    }

    private void Update()
    {
        if (_shakeTimer > 0)
        {
            _shakeTimer -= Time.deltaTime;

            _cameraModule.m_AmplitudeGain = Mathf.Lerp(0f, _startingIntensity, _shakeTimer / _shakeTimerTotal);
        }
    }

    private void OnEnable()
    {
        Player.ShakeEvent += OnShake;
    }

    private void OnDisable()
    {
        Player.ShakeEvent -= OnShake;
    }
}