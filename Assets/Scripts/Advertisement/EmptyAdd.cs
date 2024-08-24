using System;

namespace Advertisement
{
    public class EmptyAdd : IShowAd
    {
        public void ShowFullscreenAd() => FullscreenAdCloseEvent?.Invoke();

        public event Action FullscreenAdCloseEvent;
        public event Action FullscreenAdErrorEvent;
        public void ShowRewardVideo() => RewardVideoRewardedEvent?.Invoke();

        public event Action RewardVideoOpenEvent;
        public event Action RewardVideoRewardedEvent;
        public event Action RewardVideoOpenClose;
        public event Action RewardVideoOpenError;
    }
}