mergeInto(LibraryManager.library, {
	SetScoreExtern: function(score) 
	{
    	ysdk.getLeaderboards()
          .then(lb => {
            lb.setLeaderboardScore('leaderboard', score);
        });
  	}
 });