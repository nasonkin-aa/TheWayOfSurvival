using System;
using Advertisement;
using Leaderboard;
using UnityEngine;

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
        ShowAd = new EmptyAdd();
#else
        _leaderboard = new YandexLeaderboard();
        ShowAd = YandexAd.Create();
#endif
    }

    private void Start()
    {
        ShowAd.ShowFullscreenAd();
    }

    private void OnEnable()
    {
        Player.Instance.Health.DeathEvent += OnGameEnded;
        Totem.Instance.Health.DeathEvent += OnGameEnded;

        ShowAd.FullscreenAdCloseEvent += OnFullscreenAdClose;
    }

    private void OnFullscreenAdClose()
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