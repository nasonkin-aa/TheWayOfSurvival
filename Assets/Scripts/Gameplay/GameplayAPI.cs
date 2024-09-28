using System.Runtime.InteropServices;

namespace Gameplay
{
    public class GameplayAPI : IGameplay
    {
        public void Start() => StartExtern();
        public void Stop() => StopExtern();

        [DllImport("__Internal")]
        private static extern void StartExtern();

        [DllImport("__Internal")]
        private static extern void StopExtern();
    }
}