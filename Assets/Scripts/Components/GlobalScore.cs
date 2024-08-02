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

    public static void ObjectsLoad()
    {
        LightWorld.OnNightStart += NightStart;
    }

    public static void GameFinished()
    {
        LightWorld.OnNightStart -= NightStart;
    }

    public static void AddPoints(int amount) => Score += amount;
    private static void NightStart() => AddPoints(200);
}
