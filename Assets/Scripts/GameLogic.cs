using System;
using Advertisement;
using Leaderboard;
using UnityEngine;
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

        ShowAd.FullscreenAdOpenEvent += StopGameForYandexAd;
        ShowAd.FullscreenAdCloseEvent += StartGameForYandexAd;
        
        ShowAd.RewardVideoOpenEvent += StopGameForYandexAd;
        ShowAd.RewardVideoCloseEvent += StartGameForYandexAd;
    }

    private void OnGameEnded()
    {
        EndedEvent?.Invoke();
        
        _leaderboard.SetEntry(new LeaderboardEntry.Builder().WithScore(GlobalScore.Score).Build());
        GlobalScore.Dispose();

        SceneManager.LoadScene("GameOver");
    }

    private void StopGameForYandexAd()
    {
        PauseSystem.Pause(this);
        AudioManager.AllAudioPause();
        var Modifier = GameObject.FindObjectOfType<DrawModifier>();
        Modifier.DisableButtonAd();
    }
    private void StartGameForYandexAd()
    {
        PauseSystem.Unpause(this);
        AudioManager.AllAudioUnPause();
    }
}