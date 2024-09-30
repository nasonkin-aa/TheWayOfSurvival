mergeInto(LibraryManager.library, {
    ReadyExtern : function () {
        if (ysdk.features.LoadingAPI) {
            ysdk.features.LoadingAPI.ready()
        }
    },
});
