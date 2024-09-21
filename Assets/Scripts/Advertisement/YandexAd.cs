using System;
using System.Runtime.InteropServices;
using Advertisement;
using UnityEngine;

public class YandexAd : MonoBehaviour, IShowAd
{
    public void ShowFullscreenAd() => ShowFullscreenAdExtern();

    public event Action FullscreenAdOpenEvent;
    public event Action FullscreenAdCloseEvent;
    public event Action FullscreenAdErrorEvent;
    
    public void ShowRewardVideo() => ShowRewardVideoExtern();

    public event Action RewardVideoOpenEvent;
    public event Action RewardVideoRewardedEvent;
    public event Action RewardVideoCloseEvent;
    public event Action RewardVideoErrorEvent;

    [DllImport("__Internal")]
    private static extern void ShowFullscreenAdExtern();

    public void OnFullscreenAdOpen() => FullscreenAdOpenEvent?.Invoke();
    public void OnFullscreenAdClose(bool wasShown) => FullscreenAdCloseEvent?.Invoke();
    public void OnFullscreenAdError() => FullscreenAdErrorEvent?.Invoke();

    [DllImport("__Internal")]
    private static extern void ShowRewardVideoExtern();

    public void OnRewardVideoOpen() => RewardVideoOpenEvent?.Invoke();
    public void OnRewardVideoRewarded() => RewardVideoRewardedEvent?.Invoke();
    public void OnRewardVideoClose() => RewardVideoCloseEvent?.Invoke();
    public void OnRewardVideoError() => RewardVideoErrorEvent?.Invoke();

    public static YandexAd Create()
    {
        GameObject go = new() { name = "YandexAd" };
        return go.AddComponent<YandexAd>();
    }
}