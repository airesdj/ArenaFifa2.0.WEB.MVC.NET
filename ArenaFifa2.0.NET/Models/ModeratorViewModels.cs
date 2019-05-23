using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ArenaFifa20.NET.App_Start.CustomValidators;

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

    public class SpoolerViewModel
    {
        public string nextTimeProcessSpooler { get; set; }

        public List<SpoolerTypeModel> listSpoolerInProgress { get; set; }
        public List<SpoolerTypeModel> listSpoolerWaiting { get; set; }
        public List<SpoolerTypeModel> listSpoolerFinished { get; set; }
        public List<SpoolerTypeModel> listSpoolerAdmin { get; set; }

        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class SpoolerTypeModel
    {
        public int id { get; set; }
        public string description { get; set; }
        public string initials { get; set; }
        public DateTime dt_create { get; set; }
        public string hr_create { get; set; }
        public int totalEmails { get; set; }
        public int totalEmailsSent { get; set; }
        public int totalEmailsMissingSend { get; set; }
        public DateTime dt_last_sent { get; set; }
        public string hr_last_sent { get; set; }
        public DateTime dt_end_process { get; set; }
        public string hr_end_process { get; set; }
        public string psnID { get; set; }
        public int seasonID { get; set; }
        public int championshipID { get; set; }
        public int matchID { get; set; }
        public int stageID { get; set; }
        public int roundID { get; set; }
        public string championshipName { get; set; }
        public string frequency { get; set; }
        public string timeProcess { get; set; }
        public Boolean activeProcess { get; set; }
        public string dateFormattedLastProcessing { get; set; }
        public Boolean processedToday { get; set; }
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


    public class TeamTypeDetailsModel
    {
        public int id { get; set; }
        public string name { get; set; }
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
        public List<TeamTypeDetailsModel> listOfType { get; set; }
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
        public int totalQualifyNextStage { get; set; }
        public string console { get; set; }
        public DateTime lastUpdate { get; set; }
        public string psnIDUpdate { get; set; }
        public int totalTeamQualifyDivAbove { get; set; }
        public string stagePlayoffFormatted { get; set; }
        public int championshipDestiny { get; set; }
        public int championshipSource { get; set; }
        public int doubleRound { get; set; }
        public int userID1 { get; set; }
        public int userID2 { get; set; }
        public string userName1 { get; set; }
        public string userName2 { get; set; }
        public string psnID1 { get; set; }
        public string psnID2 { get; set; }
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
        public List<ChampionshipStageDetailsModel> listOfStage { get; set; }
        public List<ChampionshipTypeDetailsModel> listOfType { get; set; }
        public List<TeamTypeDetailsModel> listOfTeamType { get; set; }
        public List<ChampionshipUserDetailsModel> listOfUserStage2 { get; set; }
        public List<ChampionshipTeamDetailsModel> listOfTeamStage0 { get; set; }
        public List<ChampionshipUserDetailsModel> listOfModerator { get; set; }
        public List<ChampionshipDetailsModel> listOfChampionship { get; set; }
        public List<ChampionshipStageDetailsModel> listOfAllStages { get; set; }
        public List<ChampionshipUserDetailsModel> listOfAllUsers { get; set; }
        public List<ChampionshipTeamDetailsModel> listOfAllTeams { get; set; }

        //manage championship
        public List<ChampionshipUserDetailsModel> listOfUserGetIn { get; set; }
        public List<ChampionshipUserDetailsModel> listOfUserGetOut { get; set; }
        public string labelUserGetIn { get; set; }
        public string labelUserGetOut { get; set; }
        public string labelActionButton { get; set; }
        public string titleView { get; set; }
        public string pathLogoChampionship { get; set; }
        public string pathLogoType { get; set; }

        public string psnOperation { get; set; }
        public int idUserOperation { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class TeamTypeListViewModel
    {
        public List<TeamTypeDetailsModel> listOfType { get; set; }
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
    }

    public class ChampionshipTypeListViewModel
    {
        public List<ChampionshipTypeDetailsModel> listOfType { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ChampionshipTypeDetailsModel
    {
        public string id { get; set; }
        public string name { get; set; }
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
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ChampionshipStageDetailsModel
    {
        public int id { get; set; }
        public string name { get; set; }
    }

}
