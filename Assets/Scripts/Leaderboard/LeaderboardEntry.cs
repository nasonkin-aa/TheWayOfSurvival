namespace Leaderboard
{
    public struct LeaderboardEntry : ILeaderboardEntry
    {
        public int Rank { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        
        public class Builder
        {
            private LeaderboardEntry _entry;

            public Builder(LeaderboardEntry? entry = null) => _entry = entry ?? new();

            public Builder WithRank(int rank)
            {
                _entry.Rank = rank;
                return this;
            }
            
            public Builder WithName(string name)
            {
                _entry.Name = name;
                return this;
            }
            
            public Builder WithScore(int score)
            {
                _entry.Score = score;
                return this;
            }

            public LeaderboardEntry Build() => _entry;
        }
    }
}