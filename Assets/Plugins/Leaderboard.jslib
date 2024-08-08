mergeInto(LibraryManager.library, {

    Hello: function () {
        window.alert("Hello, world!");
        console.log("Hello, world!");
    },

	SetScoreExtern: function(score) 
	{
	    console.log("dsfadsssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss");
	    console.log("SetScoreExtern: " + score);
	
    	ysdk.getLeaderboards()
          .then(lb => {
            lb.setLeaderboardScore('myleaderboard', score);
        });
  	}
  	
 });