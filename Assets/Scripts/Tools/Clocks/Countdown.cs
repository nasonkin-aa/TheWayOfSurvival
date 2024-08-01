public class Countdown : Clock
{
    public Countdown(float initialTime, string timeFormat = DefaultTimeFormat) 
        : base(initialTime, timeFormat) {}

    public override void Tick(float deltaTime)
    {
        base.Tick(deltaTime);
            
        CurrentTime -= deltaTime;
        if (CurrentTime > 0) return;
                
        CurrentTime = 0;
        Stop();
    }
}