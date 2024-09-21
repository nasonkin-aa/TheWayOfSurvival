using System;
using Advertisement;
using Leaderboard;
using UnityEngine.SceneManagement;

public class GameLogic : Singleton<GameLogic>
{
    private ILeaderboard<LeaderboardEntry> _leaderboard;

    public IShowAd ShowAd { get; private set; }

    public event Action StartedEvent;
    public event Action EndedEvent;

    protected override void Awake()
    {
        base.Awake();

#if UNITY_EDITOR
        _leaderboard = new PlayerPrefsLeaderboard();
        ShowAd = new EmptyAd();
#else
        _leaderboard = new YandexLeaderboard();
        ShowAd = YandexAd.Create();
#endif
    }

    private void Start()
    {
        GlobalScore.Initialize();
        StartedEvent?.Invoke();
        ShowAd.ShowFullscreenAd();
    }

    private void OnEnable()
    {
        Player.Instance.Health.DeathEvent += OnGameEnded;
        Totem.Instance.Health.DeathEvent += OnGameEnded;

        ShowAd.FullscreenAdOpenEvent += () => PauseSystem.Pause(100);
        ShowAd.FullscreenAdCloseEvent += () => PauseSystem.Unpause(100);
    }

    private void OnGameEnded()
    {
        EndedEvent?.Invoke();
        
        _leaderboard.SetEntry(new LeaderboardEntry.Builder().WithScore(GlobalScore.Score).Build());
        GlobalScore.Dispose();

        SceneManager.LoadScene("GameOver");
    }
}