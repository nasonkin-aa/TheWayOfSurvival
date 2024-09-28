mergeInto(LibraryManager.library, {
    ShowFullscreenAdExtern : function () {
        ysdk.adv.showFullscreenAdv({
            callbacks: {
                onOpen: () => {
                    console.log('OnFullscreenAdOpen');
                    myGameInstance.SendMessage('YandexAd', 'OnFullscreenAdOpen');
                },
                onClose: () => {
                    console.log('OnFullscreenAdClose');
                    myGameInstance.SendMessage('YandexAd', 'OnFullscreenAdClose');
                },
                onError: (error) => {
                    console.log('OnFullscreenAdError');
                    myGameInstance.SendMessage('YandexAd', 'OnFullscreenAdError');
                }
            }
        })
    },

    ShowRewardVideoExtern: function () {
        ysdk.adv.showRewardedVideo({
            callbacks: {
                onOpen: () => {
                    console.log('OnRewardVideoOpen');
                    myGameInstance.SendMessage('YandexAd', 'OnRewardVideoOpen');
                },
                onRewarded: () => {
                    console.log('OnRewardVideoRewarded');
                    myGameInstance.SendMessage('YandexAd', 'OnRewardVideoRewarded');
                },
                onClose: () => {
                    console.log('OnRewardVideoClose');
                    myGameInstance.SendMessage('YandexAd', 'OnRewardVideoClose');
                },
                onError: (e) => {
                    console.log('OnRewardVideoError');
                    myGameInstance.SendMessage('YandexAd', 'OnRewardVideoError');
                }
            }
        })
    },
});