mergeInto(LibraryManager.library, {
    StartExtern : function () {
        if (ysdk.features.GameplayAPI) {
            ysdk.features.GameplayAPI.start();
        }
    },

    StopExtern: function () {
        if (ysdk.features.GameplayAPI) {
            ysdk.features.GameplayAPI.stop();
        }
    },
});
