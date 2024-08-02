using System;

public static class GlobalScore
{
    private static int _score = 0;
    public static Action<int> ChangeEvent;

    public static int Score
    {
        get => _score;
        private set 
        {
            if (value < Score || value > 100000) return;
            
            _score = value;
            ChangeEvent?.Invoke(value);
        } 
    }

    public static void Refresh()
    {
        _score = 0;
        ChangeEvent = null;
    }

    public static void Initialize()
    {
        LightWorld.NightStartEvent += NightStart;
        Soul.PickUpEvent += AddPoints;
        BaseEnemy.DeathEvent += AddPoints;
    }

    public static void Dispose()
    {
        LightWorld.NightStartEvent -= NightStart;
        Soul.PickUpEvent += AddPoints;
        BaseEnemy.DeathEvent += AddPoints;
    }

    private static void AddPoints(int amount) => Score += amount;
    private static void NightStart() => AddPoints(200);
}
