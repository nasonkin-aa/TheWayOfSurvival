using System.Collections.Generic;

namespace Leaderboard
{
    public interface ILeaderboard<T> where T : ILeaderboardEntry
    {
        void SetEntry(T entry);
        IEnumerable<T> GetEntries();

    }
}