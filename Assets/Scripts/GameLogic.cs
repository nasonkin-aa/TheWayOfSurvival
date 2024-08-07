using System;

public class GameLogic : Singleton<GameLogic>
{
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
        GlobalScore.Refresh();
        
        StartedEvent?.Invoke();
    }

    private void OnGameEnded()
    {
        EndedEvent?.Invoke();
        
        GlobalScore.Dispose();
        SceneManagerSelect.SelectSceneByName("GameOver");
    }
}