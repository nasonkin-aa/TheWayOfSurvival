using System;
using Leaderboard;

public class GameLogic : Singleton<GameLogic>
{
    private ILeaderboard<LeaderboardEntry> _leaderboard;

    public event Action StartedEvent;
    public event Action EndedEvent;

    protected override void Awake()
    {
        base.Awake();

#if UNITY_EDITOR
        _leaderboard = new PlayerPrefsLeaderboard();
#else        
        _leaderboard = new YandexLeaderboard();
#endif
    }

    private void OnEnable()
    {
        Player.Instance.Health.DeathEvent += OnGameEnded;
        Totem.Instance.Health.DeathEvent += OnGameEnded;
    }

    private void Start()
    {
        GlobalScore.Initialize();

        
        StartedEvent?.Invoke();
    }

    private void OnGameEnded()
    {
        EndedEvent?.Invoke();
        
        _leaderboard.SetEntry(new LeaderboardEntry.Builder().WithScore(GlobalScore.Score).Build());
        GlobalScore.Dispose();

        SceneManagerSelect.SelectSceneByName("GameOver");
    }
}