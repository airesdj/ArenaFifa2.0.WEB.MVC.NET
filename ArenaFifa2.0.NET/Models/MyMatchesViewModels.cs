﻿using System;
using System.Collections.Generic;

namespace ArenaFifa20.NET.Models
{
    public class MyMatchesSummaryViewModel
    {
        public int userID { get; set; }
        public int averageGoals { get; set; }
        public int totalMatches { get; set; }
        public int totalGoals { get; set; }
        public string teamNameH2H { get; set; }
        public string teamNameFUT { get; set; }
        public string teamNamePRO { get; set; }

        public string pathLogoteamH2H { get; set; }
        public string pathLogoteamFUT { get; set; }
        public string pathLogoteamPRO { get; set; }

        public List<listScorers> listOfScorersH2H { get; set; }
        public List<listScorers> listOfScorersPRO { get; set; }

        public int teamID { get; set; }
        public string psnID { get; set; }
        public string mobileNumber { get; set; }
        public string codeMobileNumber { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }


    public class MyNextMatchesViewModel
    {
        public string typeMode { get; set; }
        public int userID { get; set; }
        public string psnID { get; set; }
        public string psnIDForm { get; set; }
        public string userName { get; set; }
        public string mobileNumber { get; set; }
        public string codeMobileNumber { get; set; }
        public List<ChampionshipMatchTableDetailsModel> listOfMatch { get; set; }
        public MyMatchesTotalModel totalsMyMatches { get; set; }
        public List<listScorers> listOfScorers { get; set; }
        public List<squadListModel> listOfSquad { get; set; }
        public string sourceForm { get; set; }
        public string actionForm { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class MyMatchesTotalModel
    {
        public int totalMatchToPlay { get; set; }
        public int totalMatchDelayed { get; set; }
        public int totalMatches { get; set; }
        public int totalGoals { get; set; }
        public int totalWins { get; set; }
        public int totalLosses { get; set; }
        public int totalGoalsFor { get; set; }
        public int totalGoalsAgainst { get; set; }
        public string teamNameH2H { get; set; }
        public int teamIDH2H { get; set; }
        public string teamNameFUT { get; set; }
        public int teamIDFUT { get; set; }
        public string teamNamePRO { get; set; }
        public int teamIDPRO { get; set; }
        public string nationalTeamNameCPDM { get; set; }
        public int natonalTeamIDCPDM { get; set; }

        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }


}
