using System;
using Advertisement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartAd : MonoBehaviour
{
    public IShowAd ShowAd { get; private set; }

    protected void Awake()
    {
#if UNITY_EDITOR
        ShowAd = new EmptyAd();
#else
        ShowAd = YandexAd.Create();
#endif
    }
    private void Start()
    {
        ShowAd.ShowFullscreenAd();
    }
}
