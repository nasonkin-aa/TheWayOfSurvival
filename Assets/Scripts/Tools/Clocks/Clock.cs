using System;

public abstract class Clock
{
    public float InitialTime { get; private set; }
    public float CurrentTime { get; protected set; }

    public bool IsTicking { get; private set; }

    protected const string DefaultTimeFormat = @"mm\:ss\:fff";
    private readonly string _timeFormat;

    public event Action StartEvent;
    public event Action StopEvent;

    public event Action PauseEvent;
    public event Action ResumeEvent;

    public event Action<float> TickEvent;

    protected Clock(float initialTime, string timeFormat = DefaultTimeFormat)
    {
        InitialTime = initialTime;
        CurrentTime = initialTime;

        _timeFormat = timeFormat;
    }

    #region MainMethods

    public void Start()
    {
        if (IsTicking) return;

        StartTicking();
        StartEvent?.Invoke();
    }

    public void Stop()
    {
        if (!IsTicking) return;

        StopTicking();
        StopEvent?.Invoke();
    }

    public void Resume()
    {
        if (IsTicking) return;

        StartTicking();
        ResumeEvent?.Invoke();
    }

    public void Pause()
    {
        if (!IsTicking) return;

        StartTicking();
        PauseEvent?.Invoke();
    }

    public void Reset(float? value = null)
    {
        if (IsTicking) return;

        InitialTime = value ?? InitialTime;
        CurrentTime = InitialTime;
    }

    public void HardReset(float? value = null)
    {
        Stop();
        Reset(value);
    }

    #endregion

    #region Editing

    public void Add(float time)
    {
        if (time < 0) return;
        CurrentTime += time;
    }

    public void Subtract(float time)
    {
        if (time < 0) return;
        CurrentTime -= time;
    }

    #endregion

    #region Ticking

    public virtual void Tick(float deltaTime) => TickEvent?.Invoke(CurrentTime);
    private void StartTicking() => IsTicking = true;
    private void StopTicking() => IsTicking = false;

    #endregion

    public override string ToString() => TimeSpan.FromSeconds(CurrentTime).ToString(_timeFormat);
}