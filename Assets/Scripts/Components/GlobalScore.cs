using System;
using Souls;

public static class GlobalScore
{
    private static int _score = 0;
    public static event Action<int> ChangeEvent;

    public static int Score
    {
        get => _score;
        private set 
        {
            if (value < 0) return;
            
            _score = value;
            ChangeEvent?.Invoke(value);
        } 
    }
    
    public static void Initialize()
    {
        Score = 0;
        
        LightWorld.NightStartEvent += OnNightStart;
        SoulCollector.PickUpEvent += AddPoints;
        BaseEnemy.DeathEvent += OnEnemyDeath;
        GameLogic.Instance.EndedEvent += OnGameEnded;
    }

    public static void Dispose()
    {
        LightWorld.NightStartEvent -= OnNightStart;
        SoulCollector.PickUpEvent -= AddPoints;
        BaseEnemy.DeathEvent -= OnEnemyDeath;
        GameLogic.Instance.EndedEvent += OnGameEnded;
    }

    private static void AddPoints(int amount) => Score += amount;
    private static void OnNightStart() => AddPoints(200);
    private static void OnEnemyDeath(BaseEnemy.DeathInfo info) => AddPoints(info.Config.ScorePoints);

    private static void OnGameEnded()
    {
        AddPoints((int)(Player.Instance.Health.Percentage * 1000));
        AddPoints((int)(Totem.Instance.Health.Percentage * 2000));
    }
}
