mergeInto(LibraryManager.library, {

    Hello: function () {
        window.alert("Hello, world!");
        console.log("Hello, world!");
    },

	SetScoreExtern: function(score) 
	{
        const leaderboard = 'myleaderboard';
        
        const work = async () => {
            const lb = await ysdk.getLeaderboards();
            
            try {
                const res = await lb.getLeaderboardPlayerEntry(leaderboard);
                
                if (res.score < score) {
                    await lb.setLeaderboardScore(leaderboard, score);
                }
            } catch (err) {
                if (err.code === 'LEADERBOARD_PLAYER_NOT_PRESENT') {
                    await lb.setLeaderboardScore(leaderboard, score);
                }
            }
        }

        work();
  	}
});