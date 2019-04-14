var objCalculate;

var calculateScore = function(options){

var vars = {

iGoalsHome: 0,
iGoalsAway: 0,
sObjectGoalsHome: "",
sObjectGoalsAway: "",
sObjectListScorersHome: "",
sObjectListScorersAway: "",
sNameIDPlayerListHome: "#playerListHome",
sNameIDPlayerListAway: "#playerListAway",
sPlayerNameScorer: "",
iPlayerHome: 1,
sHtmlFromHome: "",
sHtmlFromAway: ""

}

var root = this;

this.construct = function(options){

$.extend(vars , options);

}

this.setScoreHome = function(namePlayer){

	vars.sPlayerNameScorer = namePlayer;
	vars.iPlayerHome = 1;

}

this.setScoreAway = function(namePlayer){

	vars.sPlayerNameScorer = namePlayer;
	vars.iPlayerHome = 0;

}


this.cleanScores = function(){

	$(vars.sObjectGoalsHome).text("?");
	$(vars.sObjectGoalsAway).text("?");

}

this.initializeScore = function(){

	vars.iGoalsHome = 0;
	vars.iGoalsAway = 0;
	vars.sPlayerNameScorer = "";
	vars.iPlayerHome = 1;
	
	this.cleanScores();
	
}

this.updateScore = function(){

	$(vars.sObjectGoalsHome).text(vars.iGoalsHome);
	$(vars.sObjectGoalsAway).text(vars.iGoalsAway);

}

this.increaseScore = function(){
	
	if (vars.iPlayerHome == 1) {
		
		vars.iGoalsHome = vars.iGoalsHome + 1;
		
	}
	else {
		
		vars.iGoalsAway = vars.iGoalsAway + 1;
		
	}
	
	this.validateScorerInformed();
	this.updateScore();

}

this.validateScorerInformed = function(){
	
	var iTotalSoccerBalls = 0;
	var $objectScorers;
	var sHtmlSoccerBalls = "";
	var setInfoPlayer = false;
	var indentifyOwnGoal = "";
	
	if (vars.sPlayerNameScorer.indexOf("Gol Contra")>0) {indentifyOwnGoal = "own-goal";}
	
	if (vars.iPlayerHome==1) {
		$objectScorers = $(vars.sObjectListScorersHome).children("p.time-jogador");
	}
	else {
		$objectScorers = $(vars.sObjectListScorersAway).children("p.time-jogador");
	}
	
	if ($objectScorers.length==0) {
		if (vars.iPlayerHome == 1) {
			
			vars.sHtmlFromHome = vars.sHtmlFromHome + 
								 "<p class='time-jogador ' target='"+vars.sPlayerNameScorer+"'>"+vars.sPlayerNameScorer+"&nbsp; <span id='soccer-ball'><i class='gentelella-fa gentelella-fa-soccer-ball-o "+indentifyOwnGoal+"'></i>&nbsp;</span><span></p>";
			
			$(vars.sObjectListScorersHome).html(vars.sHtmlFromHome);
			
		}
		else {
			
			vars.sHtmlFromAway = vars.sHtmlFromAway + 
								 "<p class='time-jogador ' target='"+vars.sPlayerNameScorer+"'>"+vars.sPlayerNameScorer+"&nbsp; <span id='soccer-ball'><i class='gentelella-fa gentelella-fa-soccer-ball-o "+indentifyOwnGoal+"'></i>&nbsp;</span><span></p>";
			
			$(vars.sObjectListScorersAway).html(vars.sHtmlFromAway);
			
		}
	}
	else {
		for (var i = 0;i<$objectScorers.length;i++) {
			if ($objectScorers.eq(i).attr("target")==vars.sPlayerNameScorer) {
				iTotalSoccerBalls = $objectScorers.eq(i).children("#soccer-ball").children("i.gentelella-fa-soccer-ball-o").length;
				if (iTotalSoccerBalls>0) {
					setInfoPlayer = true;
					iTotalSoccerBalls += 1;
					for (var j = 0;j<iTotalSoccerBalls;j++) {
						sHtmlSoccerBalls += "<i class='gentelella-fa gentelella-fa-soccer-ball-o "+indentifyOwnGoal+"'></i>&nbsp;";
					}
					$objectScorers.eq(i).children("#soccer-ball").html(sHtmlSoccerBalls);
				}
			}
		}
		if (setInfoPlayer==false) {
			if (vars.iPlayerHome == 1) {
				
				vars.sHtmlFromHome = vars.sHtmlFromHome + 
									 "<p class='time-jogador ' target='"+vars.sPlayerNameScorer+"'>"+vars.sPlayerNameScorer+"&nbsp; <span id='soccer-ball'><i class='gentelella-fa gentelella-fa-soccer-ball-o "+indentifyOwnGoal+"'></i>&nbsp;</span><span></p>";
				
				$(vars.sObjectListScorersHome).html(vars.sHtmlFromHome);
				
			}
			else {
				
				vars.sHtmlFromAway = vars.sHtmlFromAway + 
									 "<p class='time-jogador ' target='"+vars.sPlayerNameScorer+"'>"+vars.sPlayerNameScorer+"&nbsp; <span id='soccer-ball'><i class='gentelella-fa gentelella-fa-soccer-ball-o "+indentifyOwnGoal+"'></i>&nbsp;</span><span></p>";
				
				$(vars.sObjectListScorersAway).html(vars.sHtmlFromAway);
				
			}
		}
	}
}

this.decreaseScore = function(){

	
	if (vars.iPlayerHome == 1) {
		
		vars.iGoalsHome = vars.iGoalsHome - 1;
		if (vars.iGoalsHome<0) {vars.iGoalsHome = 0;}
		
		$(vars.sObjectListScorersHome).find("[target='"+vars.sPlayerNameScorer+"'").remove();
	}
	else {

		vars.iGoalsAway = vars.iGoalsAway - 1;
		if (vars.iGoalsAway<0) {vars.iGoalsAway = 0;}
		
		$(vars.sObjectListScorersAway).find("[target='"+vars.sPlayerNameScorer+"'").remove();
	
	}
	
	this.updateScore();

}

this.putScore0x0 = function(){

	this.cleanAllScorers();

	vars.iGoalsHome = 0;
	vars.iGoalsAway = 0;
	
	this.updateScore();

}

this.cleanAllScorers = function(){

	this.initializeScore();

	$(vars.sObjectListScorersHome).html("");
	$(vars.sObjectListScorersAway).html("");
	
	vars.sHtmlFromHome = "";
	vars.sHtmlFromAway = "";

}


this.beforeSubmit = function(){

}

 
this.construct(options);

}