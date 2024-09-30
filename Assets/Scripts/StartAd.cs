using Advertisement;
using Loading;
using UnityEngine;

public class StartAd : MonoBehaviour
{
    public IShowAd ShowAd { get; private set; }
    public ILoading Loading { get; private set; }

    protected void Awake()
    {
#if UNITY_EDITOR
        ShowAd = new EmptyAd();
        Loading = new EmptyLoading();
#else
        ShowAd = YandexAd.Create();
        Loading = new LoadingAPI();
#endif

        Loading.Ready();
    }

    private void Start()
    {
        ShowAd.ShowFullscreenAd();
    }
}
