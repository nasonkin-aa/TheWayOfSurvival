using System;
using UnityEngine;
using TMPro;

public class ClockUI : MonoBehaviour
{
    private enum ClockType : byte
    {
        Countdown,
        Stopwatch
    }
    
    [SerializeField] private TMP_Text tmpText;
    [SerializeField] private ClockType type;
    [SerializeField] private string format = "mm\\:ss";
    
    [SerializeField] private int initialMinutes = 2;
    [SerializeField] private int initialSeconds = 30;
    
    private Clock _innerClock;

    private void Awake()
    {
        gameObject.AssignComponentIfUnityNull(ref tmpText);
        
        _innerClock = type switch
        {
            ClockType.Countdown => new Countdown(initialMinutes * 60 + initialSeconds, format),
            ClockType.Stopwatch => new Stopwatch(0, format),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private void Start() => UpdateText();

    private void OnEnable()
    {
        GameLogic.Instance.StartedEvent += OnGameStarted;
    }

    /*private void OnDisable()
    {
        GameLogic.Instance.StartedEvent -= OnGameStarted;
    }*/

    private void OnGameStarted() => _innerClock.Start();
    
    private void Update()
    {
        _innerClock.Tick(Time.deltaTime);
        UpdateText();
    }

    private void UpdateText() => tmpText.text = _innerClock.ToString();
}