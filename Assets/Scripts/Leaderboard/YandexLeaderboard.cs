using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Leaderboard
{
    public class YandexLeaderboard : ILeaderboard<LeaderboardEntry>
    {
        private readonly IEnumerable<LeaderboardEntry> _cachedEntries = Array.Empty<LeaderboardEntry>();

        public void SetEntry(LeaderboardEntry entry) => SetScoreExtern(entry.Score);
        public IEnumerable<LeaderboardEntry> GetEntries() => _cachedEntries;
        
        [DllImport("__Internal")]
        private static extern void SetScoreExtern(int score);
    }
}