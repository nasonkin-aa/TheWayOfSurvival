using System;

namespace Advertisement
{
    public class EmptyAd : IShowAd
    {
        public void ShowFullscreenAd()
        {
            FullscreenAdOpenEvent?.Invoke();
            FullscreenAdCloseEvent?.Invoke();
        }

        public event Action FullscreenAdOpenEvent;
        public event Action FullscreenAdCloseEvent;
        public event Action FullscreenAdErrorEvent;

        public void ShowRewardVideo()
        {
            RewardVideoOpenEvent?.Invoke();
            RewardVideoRewardedEvent?.Invoke();
            RewardVideoCloseEvent?.Invoke();
        }

        public event Action RewardVideoOpenEvent;
        public event Action RewardVideoRewardedEvent;
        public event Action RewardVideoCloseEvent;
        public event Action RewardVideoErrorEvent;
    }
}