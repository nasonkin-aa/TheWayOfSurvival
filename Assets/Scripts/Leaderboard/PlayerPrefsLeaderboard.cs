using System;
using System.Collections.Generic;
using UnityEngine;

namespace Leaderboard
{
    public class PlayerPrefsLeaderboard : ILeaderboard<LeaderboardEntry>
    {
        private const string ScoreKey = "Score";
        
        private readonly IEnumerable<LeaderboardEntry> _cachedEntries = Array.Empty<LeaderboardEntry>();
        
        public void SetEntry(LeaderboardEntry entry)
        {
            int previousScore = PlayerPrefs.GetInt(ScoreKey, -1);

            if (previousScore == -1 || previousScore < entry.Score)
            {
                PlayerPrefs.SetInt(ScoreKey, entry.Score);
                Debug.Log($"New score{entry.Score}");
            }
        }

        public IEnumerable<LeaderboardEntry> GetEntries() => _cachedEntries;
    }
}