using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ArenaFifa20.NET.Models
{
    public class ModeratorSummaryViewModel
    {
        public int totalActiveCoaches { get; set; }
        public int totalSeasonCoaches { get; set; }
        public string currentStageNameH2H { get; set; }
        public string seasonNameH2H { get; set; }
        public string seasonNameFUT { get; set; }
        public string seasonNamePRO { get; set; }

        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class StandardDetailsModel_v2
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string pathImg { get; set; }
    }

    public class StandardDetailsModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string pathImg { get; set; }
    }

    public class SeasonListModesViewModel
    {
        public List<SeasonDetails> listOfSeasons { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class SeasonDetails
    {
        public int id { get; set; }
        public string name { get; set; }
        public byte active { get; set; }
        public DateTime dtStartSeason { get; set; }
        public DateTime dtEndSeason { get; set; }
        public string typeMode { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class BenchModesViewModel
    {
        public List<BenchDetailsModel> listOfBench { get; set; }
        public List<UserDetailsModel> listOfUser { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class BenchDetailsModel
    {
        public int id { get; set; }
        public int userID { get; set; }
        public string psnID { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public string team { get; set; }
        public DateTime dateStarted { get; set; }
        public DateTime dateFinished { get; set; }
        public string console { get; set; }
        public string typeBench { get; set; }
        public string actionUser { get; set; }
    }


    public class TeamDetailsModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string typeMode { get; set; }
        public int typeModeID { get; set; }
        public int teamSofifaID { get; set; }
        public byte teamDeleted { get; set; }
        public string teamSofifaURL { get; set; }
        public byte hasImage { get; set; }
        public int userID { get; set; }
        public string userName { get; set; }
        public string psnID { get; set; }
        public string pathLogo { get; set; }
        public List<StandardDetailsModel> listOfType { get; set; }
        public List<UserDetailsModel> listOfUser { get; set; }
        public List<ScorerDetails> listOfScorer { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class AcceptingNewSeasonViewModel
    {
        public string primaryKey { get; set; }
        public int seasonID { get; set; }
        public int userID { get; set; }
        public int championshipID { get; set; }
        public string confirmation { get; set; }
        public string teamName { get; set; }
        public string ordering { get; set; }

        public List<AcceptingDetails> listOfAccepting { get; set; }

        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class AcceptingDetails
    {
        public string primaryKey { get; set; }
        public int seasonID { get; set; }
        public int userID { get; set; }
        public int championshipID { get; set; }
        public string seasonName { get; set; }
        public string userName { get; set; }
        public string psnID { get; set; }
        public string championshipName { get; set; }
        public string confirmation { get; set; }
        public string confirmationDescription { get; set; }
        public DateTime Dateconfirmation { get; set; }
        public string DateconfirmationFormatted { get; set; }
        public string teamName { get; set; }
        public string console { get; set; }
        public string statusID { get; set; }
        public string statusDescription { get; set; }
        public int teamPROID { get; set; }
        public string ordering { get; set; }
        public string ddd { get; set; }
        public string mobileNumber { get; set; }
        public Boolean uploadTeamLogo { get; set; }
        public int totalPoints { get; set; }
        public int totalBlackList { get; set; }
        public List<UserDetailsModel> listOfUser { get; set; }
        public List<ChampionshipDetailsModel> listOfChampionship { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ScorerViewModel
    {
        public int id { get; set; }
        public string scorerType { get; set; }

        public List<ScorerDetails> listOfScorer { get; set; }

        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ScorerDetails
    {
        public string scorerType { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public int teamID { get; set; }
        public string teamType { get; set; }
        public string teamName { get; set; }
        public string link { get; set; }
        public string country { get; set; }
        public string sofifaTeamID { get; set; }
        public string rating { get; set; }
        public int userID { get; set; }
        public DateTime DateSubscription { get; set; }
        public string DateSubscriptionFormatted { get; set; }
        public List<TeamDetailsModel> listOfTeam { get; set; }
        public string imagePath { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }


    public class UserViewModel
    {
        public int id { get; set; }
        public List<UserDetailsModel> listOfUser { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class UserDetailsModel
    {
        public int id { get; set; }
        public string psnID { get; set; }
        public string name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime birthday { get; set; }
        public string birthdayFormatted { get; set; }
        public string state { get; set; }
        public string howfindus { get; set; }
        public string whatkindofmedia { get; set; }
        public string team { get; set; }
        public string yourmode { get; set; }
        public byte receiveWarningEachRound { get; set; }
        public byte receiveTeamTable { get; set; }
        public byte wishParticipate { get; set; }

        public IEnumerable<SelectListItem> listWhatHowFindUs { get; set; }
        public IEnumerable<SelectListItem> listStates { get; set; }
        public IEnumerable<SelectListItem> listTeams { get; set; }

        public bool userActive { get; set; }
        public bool userModerator { get; set; }
        public string dateRegister { get; set; }
        public string dateLastUpdate { get; set; }
        public int idOperator { get; set; }
        public string psnIDOperator { get; set; }
        public string pageName { get; set; }
        public string avatarPath { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class TeamListViewModel
    {
        public int id { get; set; }
        public string teamType { get; set; }
        public List<TeamDetailsModel> listOfTeam { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class BlogListViewModel
    {
        public int id { get; set; }
        public int userID { get; set; }
        public List<BlogDetailsModel> listOfBlog { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class BlogDetailsModel
    {
        public int id { get; set; }
        public int userID { get; set; }
        public string psnID { get; set; }
        public string userName { get; set; }
        public string title { get; set; }
        public DateTime registerDate { get; set; }
        public String registerDateFormatted { get; set; }
        public double registerDateTimeFormatted { get; set; }
        public string registerTime { get; set; }
        public string text { get; set; }
        public List<ChampionshipUserDetailsModel> listOfUser { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ChampionshipListViewModel
    {
        public int id { get; set; }
        public List<ChampionshipDetailsModel> listOfChampionship { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ChampionshipDetailsModel
    {
        public int id { get; set; }
        public int seasonID { get; set; }
        public string name { get; set; }
        public int totalTeam { get; set; }
        public DateTime startDate { get; set; }
        public String startDateFormatted { get; set; }
        public DateTime drawDate { get; set; }
        public String drawDateFormatted { get; set; }
        public Boolean active { get; set; }
        public Boolean forGroup { get; set; }
        public Boolean twoTurns { get; set; }
        public Boolean justOneTurn { get; set; }
        public int totalGroup { get; set; }
        public Boolean playoff { get; set; }
        public Boolean twoLegs { get; set; }
        public int totalQualify { get; set; }
        public int totalRelegation { get; set; }
        public int totalDayStageOne { get; set; }
        public int totalDayStagePlayoff { get; set; }
        public string type { get; set; }
        public string typeName { get; set; }
        public string modeType { get; set; }
        public int totalQualifyNextStage { get; set; }
        public int sourcePlaceFromChampionshipSource { get; set; }
        public int ChampionshipIDDestiny { get; set; }
        public int ChampionshipIDSource { get; set; }
        public string console { get; set; }
        public DateTime lastUpdate { get; set; }
        public string psnIDUpdate { get; set; }
        public int totalTeamQualifyDivAbove { get; set; }
        public string stagePlayoffFormatted { get; set; }
        public int doubleRound { get; set; }
        public int userID1 { get; set; }
        public int userID2 { get; set; }
        public string userName1 { get; set; }
        public string userName2 { get; set; }
        public string psnID1 { get; set; }
        public string psnID2 { get; set; }
        public string email1 { get; set; }
        public string email2 { get; set; }
        public string pathAvatar1 { get; set; }
        public string pathAvatar2 { get; set; }
        public string teamName1 { get; set; }
        public string teamName2 { get; set; }
        public int started { get; set; }
        public int firstStageID { get; set; }
        public string seasonName { get; set; }
        public string listTeamsAdd { get; set; }
        public string listUsersAdd { get; set; }
        public string listStagesAdd { get; set; }
        public string listUsersStage2Add { get; set; }
        public string listTeamsStage0Add { get; set; }
        public List<ChampionshipTeamDetailsModel> listOfTeam { get; set; }
        public List<ChampionshipUserDetailsModel> listOfUser { get; set; }
        public List<StandardDetailsModel> listOfStage { get; set; }
        public List<StandardDetailsModel_v2> listOfType { get; set; }
        public List<StandardDetailsModel> listOfTeamType { get; set; }
        public List<ChampionshipUserDetailsModel> listOfUserStage2 { get; set; }
        public List<StandardDetailsModel> listOfTeamStage0 { get; set; }
        public List<ChampionshipUserDetailsModel> listOfModerator { get; set; }
        public List<ChampionshipDetailsModel> listOfChampionship { get; set; }
        public List<StandardDetailsModel> listOfAllStages { get; set; }
        public List<ChampionshipUserDetailsModel> listOfAllUsers { get; set; }
        public List<StandardDetailsModel> listOfAllTeams { get; set; }

        //manage championship
        public List<ChampionshipUserDetailsModel> listOfUserGetIn { get; set; }
        public List<ChampionshipUserDetailsModel> listOfUserGetOut { get; set; }
        public string labelUserGetIn { get; set; }
        public string labelUserGetOut { get; set; }
        public string labelActionButton { get; set; }
        public string titleView { get; set; }
        public string pathLogoChampionship { get; set; }
        public string pathLogoType { get; set; }

        //draw
        public int drawDoneMatchTable { get; set; }
        public int totalMatchesPerRound { get; set; }
        public List<ChampionshipMatchTableDetailsModel> listOfMatch { get; set; }
        public List<StandardDetailsModel> listOfGroup { get; set; }
        public int drawDoneTeamTableGroup { get; set; }
        public List<ChampionshipTeamTableDetailsModel> listOfTeamTable { get; set; }

        public int drawDoneUserTeam { get; set; }
        public List<UserTeamDetailsModel> listOfUserTeam { get; set; }

        public CurrentSeasonMenuViewModel menuCurrentSeason { get; set; }
        public List<ChampionshipMatchTableClashesByTeamModel> listOfClashes { get; set; }

        public string stageID_Round { get; set; }
        public string psnOperation { get; set; }
        public int idUserOperation { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ChampionshipMatchTableViewModel
    {
        public List<ChampionshipMatchTableDetailsModel> listOfMatch { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ChampionshipTeamTableListViewModel
    {
        public List<ChampionshipTeamTableDetailsModel> listOfTeamTable { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }


    public class ChampionshipGroupListViewModel
    {
        public List<StandardDetailsModel> listOfGroup { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }


    public class ChampionshipMatchTableDetailsModel
    {
        public int matchID { get; set; }
        public int championshipID { get; set; }
        public string championshipName { get; set; }
        public string seasonName { get; set; }
        public int stageID { get; set; }
        public string stageName { get; set; }
        public int groupID { get; set; }
        public string groupName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int teamHomeID { get; set; }
        public int teamAwayID { get; set; }
        public string totalGoalsHome { get; set; }
        public string totalGoalsAway { get; set; }
        public DateTime launchDate { get; set; }
        public int round { get; set; }
        public string roundDetails { get; set; }
        public int userHomeID { get; set; }
        public string userHomeName { get; set; }
        public string psnIDHome { get; set; }
        public int userAwayID { get; set; }
        public string userAwayName { get; set; }
        public string psnIDAway { get; set; }
        public int playoffGame { get; set; }
        public string teamNameHome { get; set; }
        public string teamURLHome { get; set; }
        public int teamWithImageHome { get; set; }
        public string teamTypeHome { get; set; }
        public string teamNameAway { get; set; }
        public string teamURLAway { get; set; }
        public int teamWithImageAway { get; set; }
        public string teamTypeAway { get; set; }
        public string pathLogoChampionship { get; set; }
        public string pathLogoType { get; set; }
        public string pathLogoTeamHome { get; set; }
        public string pathLogoTeamAway { get; set; }
        public string modeType { get; set; }
        public int userIDAction { get; set; }
        public string psnIDAction { get; set; }
        public string psnIDSearch { get; set; }
        public string messageBlackList { get; set; }
        public string typeBlackList { get; set; }
        public int userID1 { get; set; }
        public int userID2 { get; set; }
        public int blackListIDUser1 { get; set; }
        public string messageBlackListUser1 { get; set; }
        public int blackListIDUser2 { get; set; }
        public string messageBlackListUser2 { get; set; }
        public string userName1 { get; set; }
        public string userName2 { get; set; }
        public string psnID1 { get; set; }
        public string psnID2 { get; set; }
        public int totalRecordsOfHistoric { get; set; }
        public Boolean launchResultReleased { get; set; }
        public List<ScorerDetails> listOfScorerTeamHome { get; set; }
        public List<ScorerDetails> listOfScorerTeamAway { get; set; }
        public List<ScorerMatchDetails> listOfScorerMatch { get; set; }
        public List<ChampionshipCommentMatchDetailsModel> listOfCommentMatch { get; set; }
        public List<ChampionshipCommentMatchUsersDetailsModel> listOfUsersCommentMatch { get; set; }
        public List<ChampionshipMatchTableDetailsModel> listOfMatch { get; set; }
        public ChampionshipMatchTableClashesHistoryTotalswModel historyCoachClash { get; set; }
        public ChampionshipMatchTableClashesHistoryTotalsByTeamswModel historyTeamClash { get; set; }
        public string sourceForm { get; set; }
        public string actionForm { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }


    public class ChampionshipTeamTableDetailsModel
    {
        public int championshipID { get; set; }
        public int teamID { get; set; }
        public int groupID { get; set; }
        public int totalPoint { get; set; }
        public int totalPlayed { get; set; }
        public int totalWon { get; set; }
        public int totalDraw { get; set; }
        public int totalLost { get; set; }
        public int totalGoalsFOR { get; set; }
        public int totalGoalsAGainst { get; set; }
        public int orden { get; set; }
        public string teamName { get; set; }
        public string teamURL { get; set; }
        public string teamType { get; set; }
        public int userID { get; set; }
        public string userName { get; set; }
        public string psnID { get; set; }
        public int deletedCurrentSeason { get; set; }
        public int previousPosition { get; set; }
        public string pathTeamLogo { get; set; }
        public string actionUser { get; set; }
    }


    public class TeamTypeListViewModel
    {
        public List<StandardDetailsModel> listOfType { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ChampionshipTeamListViewModel
    {
        public List<ChampionshipTeamDetailsModel> listOfTeam { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ChampionshipTeamDetailsModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string pathImg { get; set; }
        public int userID { get; set; }
        public string userName { get; set; }
        public string psnID { get; set; }
    }

    public class ChampionshipTypeListViewModel
    {
        public List<StandardDetailsModel> listOfType { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ChampionshipUserListViewModel
    {
        public List<ChampionshipUserDetailsModel> listOfUser { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ChampionshipUserDetailsModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string psnID { get; set; }
        public string email { get; set; }
        public string actionUser { get; set; }
    }

    public class ChampionshipStageListViewModel
    {
        public List<ChampionshipStageDetailsModel> listOfStage { get; set; }
        public int championshipID { get; set; }
        public int stageID { get; set; }
        public int previousStageID { get; set; }
        public DateTime startStageDate { get; set; }
        public string championshipName { get; set; }
        public string championshipType { get; set; }
        public string pathLogoChampionship { get; set; }
        public string pathLogoType { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ChampionshipStageDetailsModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int totalMatchesNoResult { get; set; }
        public int existMatches { get; set; }
        public string status { get; set; }
    }

    public class ScorerMatchViewModel
    {
        public int matchID { get; set; }
        public int championshipID { get; set; }

        public List<ScorerMatchDetails> listOfScorerMatch { get; set; }

        public string loadScorersIDHome { get; set; }
        public string loadScorersIDAway { get; set; }
        public string loadScorersGoalsHome { get; set; }
        public string loadScorersGoalsAway { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ScorerMatchDetails
    {
        public int teamID { get; set; }
        public string teamName { get; set; }
        public string teamType { get; set; }
        public int scorerID { get; set; }
        public string scorerName { get; set; }
        public string scorerNickname { get; set; }
        public int totalGoals { get; set; }
        public string sideScorer { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ChampionshipCommentMatchListViewModel
    {
        public List<ChampionshipCommentMatchDetailsModel> listOfCommentMatch { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ChampionshipCommentMatchUsersListViewModel
    {
        public List<ChampionshipCommentMatchUsersDetailsModel> listOfUsersCommentMatch { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ChampionshipCommentMatchDetailsModel
    {
        public int id { get; set; }
        public int matchID { get; set; }
        public int championshipID { get; set; }
        public int userID { get; set; }
        public string userName { get; set; }
        public string psnID { get; set; }
        public DateTime commentDate { get; set; }
        public string commentHour { get; set; }
        public string comment { get; set; }
        public string teamName { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ChampionshipCommentMatchUsersDetailsModel
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public string psnID { get; set; }
        public string email { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class UserTeamViewModel
    {
        public int championshipID { get; set; }
        public int userID { get; set; }
        public int teamID { get; set; }
        public int drawDone { get; set; }
        public List<UserTeamDetailsModel> listOfUserTeam { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class UserTeamDetailsModel
    {
        public int championshipID { get; set; }
        public int userID { get; set; }
        public int teamID { get; set; }
        public string userName { get; set; }
        public string psnID { get; set; }
        public string teamName { get; set; }
        public string teamType { get; set; }
    }

    public class DrawViewModel
    {
        public int championshipID { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

}
