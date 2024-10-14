using Advertisement;
using Gameplay;
using Loading;
using UnityEngine;

public class StartAd : MonoBehaviour
{
    public IShowAd ShowAd { get; private set; }
    public ILoading Loading { get; private set; }
    public IGameplay Gameplay { get; private set; }

    protected void Awake()
    {
#if UNITY_EDITOR
        ShowAd = new EmptyAd();
        Loading = new EmptyLoading();
        Gameplay = new EmptyGameplay();
#else
        ShowAd = YandexAd.Create();
        Loading = new LoadingAPI();
        Gameplay = new GameplayAPI();
#endif    
    }

    private void Start()
    {
        Gameplay.Start();
        Gameplay.Stop();
        ShowAd.ShowFullscreenAd();

        Loading.Ready();
    }
}
