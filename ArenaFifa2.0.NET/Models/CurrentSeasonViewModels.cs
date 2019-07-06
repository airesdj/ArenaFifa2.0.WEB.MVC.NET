using System;
using System.Collections.Generic;

namespace ArenaFifa20.NET.Models
{
    public class CurrentSeasonSummaryViewModel
    {
        public int championshipID { get; set; }
        public int userID { get; set; }
        public string modeType { get; set; }
        public int averageGoals { get; set; }
        public int totalMatches { get; set; }
        public int totalGoals { get; set; }
        public int anotherChampionshipID { get; set; }
        public int totalGroupPerChampionship { get; set; }
        public int totalQualifiedPerGroup { get; set; }
        public int placeQualifiedPerGroup { get; set; }

        public List<listScorers> listOfScorersH2H { get; set; }
        public List<listScorers> listOfScorersPRO { get; set; }
        public List<listScorers> listOfScorers { get; set; }
        public List<ChampionshipTeamTableDetailsModel> listOfTeamTableSerieA { get; set; }
        public List<ChampionshipTeamTableDetailsModel> listOfTeamTableSerieB { get; set; }
        public CurrentSeasonMenuViewModel menuCurrentSeason { get; set; }
        public List<StandardDetailsModel> listOfGroup { get; set; }
        public List<ChampionshipTeamTableDetailsModel> listOfTeamTable { get; set; }
        public List<ChampionshipTeamDetailsModel> listOfTeam { get; set; }
        public List<ChampionshipTeamTableDetailsModel> listOfForecastTeamQualified { get; set; }
        public List<ChampionshipTeamTableDetailsModel> listOfForecastTeamQualifiedThirdPlace { get; set; }

        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class CurrentSeasonMenuViewModel
    {
        public string modeType { get; set; }
        public int currentChampionshipID { get; set; }
        public string currentChampionshipName { get; set; }
        public int currentChampionshipForGroup { get; set; }
        public string currentSeasonName { get; set; }
        public string currentSeasonType { get; set; }
        public List<ActiveChampionshipTypeOfCurrentSeason> listOfActiveChampionship { get; set; }
        public List<ActiveChampionshipTypeOfCurrentSeason> listOfActiveSeasonType { get; set; }
        public List<ChampionshipDetailsModel> listOActiveChampionship { get; set; }
        public List<OtherModeTypeOfCurrentSeason> listOtherModeType { get; set; }
        public ChampionshipDetailsModel currentChampionshipDetails { get; set; }
        public int championshipSerieAID { get; set; }
        public int championshipSerieBID { get; set; }
        public int championshipSerieAForGroup { get; set; }
        public int championshipSerieBForGroup { get; set; }
        public int userHasTeamFUT { get; set; }
        public int userHasTeamPRO { get; set; }
        public string teamName { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ActiveChampionshipTypeOfCurrentSeason
    {
        public int id { get; set; }
        public string name { get; set; }
        public string modeType { get; set; }
        public string partialURL { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class OtherModeTypeOfCurrentSeason
    {
        public string name { get; set; }
        public string modeType { get; set; }
        public string url { get; set; }
    }


    public class ChampionshipMatchTableClashesHistoryTotalswModel
    {
        public int userIDLogged { get; set; }
        public string psnIDLogged { get; set; }
        public int userIDSearch { get; set; }
        public string psnIDSearch { get; set; }
        public int totalWinUsuLogged { get; set; }
        public int totalWinUsuSearch { get; set; }
        public int totalDraw { get; set; }
        public int totalLossUsuLogged { get; set; }
        public int totalLossUsuSearch { get; set; }
        public int totalGoalsUsuLogged { get; set; }
        public int totalGoalsUsuSearch { get; set; }
        public List<ChampionshipMatchTableDetailsModel> listOfMatchWinUsuLogged { get; set; }
        public List<ChampionshipMatchTableDetailsModel> listOfMatchDraw { get; set; }
        public List<ChampionshipMatchTableDetailsModel> listOfMatchWinUsuSearch { get; set; }
        public CurrentSeasonMenuViewModel menuCurrentSeason { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ChampionshipMatchTableClashesHistoryTotalsByTeamswModel
    {
        public int teamIDHome { get; set; }
        public string teamNameHome { get; set; }
        public int teamIDAway { get; set; }
        public string teamNameAway { get; set; }
        public int totalWinTeamHome { get; set; }
        public int totalWinTeamAway { get; set; }
        public int totalDraw { get; set; }
        public int totalLossTeamHome { get; set; }
        public int totalLossTeamAway { get; set; }
        public int totalGoalsTeamHome { get; set; }
        public int totalGoalsTeamAway { get; set; }
        public List<ChampionshipMatchTableDetailsModel> listOfMatchWinTeamHome { get; set; }
        public List<ChampionshipMatchTableDetailsModel> listOfMatchDraw { get; set; }
        public List<ChampionshipMatchTableDetailsModel> listOfMatchWinTeamAway { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ChampionshipCalendarListViewModel
    {
        public string modeType { get; set; }
        public List<ChampionshipCalendarDetailsModel> listOfChampionship { get; set; }
        public CurrentSeasonMenuViewModel menuCurrentSeason { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ChampionshipCalendarDetailsModel
    {
        public int championshipID { get; set; }
        public string championshipName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endStage0 { get; set; }
        public DateTime endStagePlayoff { get; set; }
        public int dayOfStage0 { get; set; }
        public int dayOfStagePlayoff { get; set; }
        public string type { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ChampionshipLineUpListViewModel
    {
        public int championshipID { get; set; }
        public string championshipName { get; set; }
        public string titleLineUp { get; set; }
        public Boolean firstStageIsQualify { get; set; }
        public Boolean clashesDefined { get; set; }
        public List<ChampionshipLineUpDetailsModel> listOfStage2 { get; set; }
        public List<ChampionshipLineUpDetailsModel> listOfRound16 { get; set; }
        public List<ChampionshipLineUpDetailsModel> listOfQuarter { get; set; }
        public List<ChampionshipLineUpDetailsModel> listOfSemi { get; set; }
        public List<ChampionshipLineUpDetailsModel> listOfGrandFinal { get; set; }
        public CurrentSeasonMenuViewModel menuCurrentSeason { get; set; }
        public int firstStageIDPlayoff { get; set; }
        public int totalStagesPlayoff { get; set; }
        public int firstStageID { get; set; }
        public int stageIDInProgress { get; set; }
        public string championTeamName { get; set; }
        public int stageIDStage2 { get; set; }
        public int stageIDRound16 { get; set; }
        public int stageIDQuarter { get; set; }
        public int stageIDSemi { get; set; }
        public int stageIDFinal { get; set; }
        public string messageNotFoundClashes { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }


    public class ChampionshipLineUpDetailsModel
    {
        public string teamName1 { get; set; }
        public string teamName2 { get; set; }
        public string teamName3 { get; set; }
        public string teamName4 { get; set; }
        public string teamName5 { get; set; }
        public string teamName6 { get; set; }
        public string teamName7 { get; set; }
        public string teamName8 { get; set; }
        public string teamName9 { get; set; }
        public string teamName10 { get; set; }
        public string teamName11 { get; set; }
        public string teamName12 { get; set; }
        public string teamName13 { get; set; }
        public string teamName14 { get; set; }
        public string teamName15 { get; set; }
        public string teamName16 { get; set; }
        public string teamName17 { get; set; }
        public string teamName18 { get; set; }
        public string teamName19 { get; set; }
        public string teamName20 { get; set; }
        public string teamName21 { get; set; }
        public string teamName22 { get; set; }
        public string teamName23 { get; set; }
        public string teamName24 { get; set; }
        public string teamName25 { get; set; }
        public string teamName26 { get; set; }
        public string teamName27 { get; set; }
        public string teamName28 { get; set; }
        public string teamName29 { get; set; }
        public string teamName30 { get; set; }
        public string teamName31 { get; set; }
        public string teamName32 { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }


    public class ChampionshipMatchTableClashesListViewModel
    {
        public List<ChampionshipMatchTableClashesByTeamModel> listOfClashes { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ChampionshipMatchTableClashesByTeamModel
    {
        public int userID { get; set; }
        public int championshipID { get; set; }
        public int teamID { get; set; }
        public string teamName { get; set; }
        public int nextMatchTeamID { get; set; }
        public string nextMatchTeamName { get; set; }
        public int nextMatchID { get; set; }
        public string pathTeam { get; set; }
        public string pathNextMatchTeam { get; set; }
        public string pathPreviousMatch1_2 { get; set; }
        public string pathPreviousMatch1_4 { get; set; }
        public string pathPreviousMatch2_2 { get; set; }
        public string pathPreviousMatch2_4 { get; set; }
        public string pathPreviousMatch3_2 { get; set; }
        public string pathPreviousMatch3_4 { get; set; }
        public string descriptionNextMatch { get; set; }
        public string descriptionPreviousMatch1_1 { get; set; }
        public string descriptionPreviousMatch1_2 { get; set; }
        public string descriptionPreviousMatch1_3 { get; set; }
        public string descriptionPreviousMatch1_4 { get; set; }
        public string statusPreviousMatch1 { get; set; }
        public int prevMatchID1 { get; set; }
        public string descriptionPreviousMatch2_1 { get; set; }
        public string descriptionPreviousMatch2_2 { get; set; }
        public string descriptionPreviousMatch2_3 { get; set; }
        public string descriptionPreviousMatch2_4 { get; set; }
        public string statusPreviousMatch2 { get; set; }
        public int prevMatchID2 { get; set; }
        public string descriptionPreviousMatch3_1 { get; set; }
        public string descriptionPreviousMatch3_2 { get; set; }
        public string descriptionPreviousMatch3_3 { get; set; }
        public string descriptionPreviousMatch3_4 { get; set; }
        public string statusPreviousMatch3 { get; set; }
        public int prevMatchID3 { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

}
