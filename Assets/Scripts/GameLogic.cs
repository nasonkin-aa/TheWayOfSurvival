using System;
using Advertisement;
using Gameplay;
using Leaderboard;
using UnityEngine.SceneManagement;

public class GameLogic : Singleton<GameLogic>
{
    private ILeaderboard<LeaderboardEntry> _leaderboard;

    public IShowAd ShowAd { get; private set; }
    public IGameplay Gameplay { get; private set; }

    public event Action StartedEvent;
    public event Action EndedEvent;

    protected override void Awake()
    {
        base.Awake();

#if UNITY_EDITOR
        _leaderboard = new PlayerPrefsLeaderboard();
        ShowAd = new EmptyAd();
        Gameplay = new EmptyGameplay();
#else
        _leaderboard = new YandexLeaderboard();
        ShowAd = YandexAd.Create();
        Gameplay = new GameplayAPI();
#endif
    }

    private void Start()
    {
        GlobalScore.Initialize();

        StartedEvent?.Invoke();

        Gameplay.Start();
        ShowAd.ShowFullscreenAd();
    }

    private void OnEnable()
    {
        Player.Instance.Health.DeathEvent += OnGameEnded;
        Totem.Instance.Health.DeathEvent += OnGameEnded;

        ShowAd.FullscreenAdOpenEvent += () => PauseSystem.Pause(this);
        ShowAd.FullscreenAdCloseEvent += () => PauseSystem.Unpause(this);

        PauseSystem.PauseEvent += Gameplay.Stop;
        PauseSystem.UnpauseEvent += Gameplay.Start;

        ShowAd.FullscreenAdOpenEvent += Gameplay.Stop;
        ShowAd.FullscreenAdErrorEvent += Gameplay.Start;
        ShowAd.FullscreenAdCloseEvent += Gameplay.Start;

        ShowAd.RewardVideoOpenEvent += Gameplay.Stop;
        ShowAd.RewardVideoErrorEvent += Gameplay.Start;
        ShowAd.FullscreenAdCloseEvent += Gameplay.Start;
    }

    private void OnGameEnded()
    {
        EndedEvent?.Invoke();
        
        Gameplay.Stop();

        _leaderboard.SetEntry(new LeaderboardEntry.Builder().WithScore(GlobalScore.Score).Build());
        GlobalScore.Dispose();

        SceneManager.LoadScene("GameOver");
    }
}