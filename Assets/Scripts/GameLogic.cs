using System;
using Leaderboard;

public class GameLogic : Singleton<GameLogic>
{
    private readonly ILeaderboard<LeaderboardEntry> _leaderboard = new PlayerPrefsLeaderboard();

    public event Action StartedEvent;
    public event Action EndedEvent;

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