using System;

namespace Advertisement
{
    public interface IShowAd
    {
        void ShowFullscreenAd();
        event Action FullscreenAdOpenEvent;
        event Action FullscreenAdCloseEvent;
        event Action FullscreenAdErrorEvent;

        void ShowRewardVideo();
        event Action RewardVideoOpenEvent;
        event Action RewardVideoRewardedEvent;
        event Action RewardVideoCloseEvent;
        event Action RewardVideoErrorEvent;
    }
}