mergeInto(LibraryManager.library, {

    ShowFullscreenAdExtern : function () {
        ysdk.adv.showFullscreenAdv({
            callbacks: {
                onClose: function(wasShown) {
                    myGameInstance.SendMessage('YandexAd', 'OnFullscreenAdClose', wasShown);
                },
                onError: function(error) {
                    myGameInstance.SendMessage('YandexAd', 'OnFullscreenAdError');
                }
            }
        })
    },

    ShowRewardVideoExtern: function () {
        ysdk.adv.showRewardedVideo({
            callbacks: {
                onOpen: () => {
                    myGameInstance.SendMessage('YandexAd', 'OnRewardVideoOpen');
                },
                onRewarded: () => {
                    myGameInstance.SendMessage('YandexAd', 'OnRewardVideoRewarded');
                },
                onClose: () => {
                    myGameInstance.SendMessage('YandexAd', 'OnRewardVideoClose');
                },
                onError: (e) => {
                    myGameInstance.SendMessage('YandexAd', 'OnRewardVideoError');
                }
            }
        })
    },
});