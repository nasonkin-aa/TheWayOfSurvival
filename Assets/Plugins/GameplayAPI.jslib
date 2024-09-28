mergeInto(LibraryManager.library, {
    StartExtern : function () {
        ysdk.features.GameplayAPI?.start();
    },

    StopExtern: function () {
        ysdk.features.GameplayAPI?.stop();
    },
});