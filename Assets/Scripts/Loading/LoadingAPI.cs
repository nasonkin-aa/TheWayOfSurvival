using System.Runtime.InteropServices;

namespace Loading
{
    public class LoadingAPI : ILoading
    {
        public void Ready() => ReadyExtern();

        [DllImport("__Internal")]
        private static extern void ReadyExtern();
    }
}