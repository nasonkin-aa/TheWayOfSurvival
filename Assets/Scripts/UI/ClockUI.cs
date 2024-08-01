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
    
    public int initialMinutes = 2;
    public int initialSeconds = 30;
    
    private Clock _innerClock;

    void Start()
    {
        tmpText ??= GetComponent<TMP_Text>();

        _innerClock = type switch
        {
            ClockType.Countdown => new Countdown(initialMinutes * 60 + initialSeconds, "mm\\:ss"),
            ClockType.Stopwatch => new Stopwatch(0, "mm\\:ss"),
            _ => throw new ArgumentOutOfRangeException()
        };
        _innerClock.Start();
        
        UpdateText();
    }

    void Update()
    {
        _innerClock.Tick(Time.deltaTime);
        UpdateText();
    }

    void UpdateText() => tmpText.text = _innerClock.ToString();
}