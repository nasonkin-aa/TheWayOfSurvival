using System;
using System.Runtime.InteropServices;
using Advertisement;
using UnityEngine;

public class YandexAd : MonoBehaviour, IShowAd
{
    public void ShowFullscreenAd()
    {
        PauseSystem.Pause();
        ShowFullscreenAdExtern();
    }

    public event Action FullscreenAdCloseEvent;
    public event Action FullscreenAdErrorEvent;
    
    public void ShowRewardVideo() => ShowRewardVideoExtern();
    public event Action RewardVideoOpenEvent;
    public event Action RewardVideoRewardedEvent;
    public event Action RewardVideoOpenClose;
    public event Action RewardVideoOpenError;

    [DllImport("__Internal")]
    private static extern void ShowFullscreenAdExtern();

    public void OnFullscreenAdClose(bool wasShown)
    {
        FullscreenAdCloseEvent?.Invoke();
        PauseSystem.Unpause();
    }
    public void OnFullscreenAdError() => FullscreenAdErrorEvent?.Invoke();

    [DllImport("__Internal")]
    private static extern void ShowRewardVideoExtern();

    public void OnRewardVideoOpen() => RewardVideoOpenEvent?.Invoke();
    public void OnRewardVideoRewarded() => RewardVideoRewardedEvent?.Invoke();
    public void OnRewardVideoClose() => RewardVideoOpenClose?.Invoke();
    public void OnRewardVideoError() => RewardVideoOpenError?.Invoke();

    public static YandexAd Create()
    {
        GameObject go = new() { name = "YandexAd" };
        return go.AddComponent<YandexAd>();
    }
}