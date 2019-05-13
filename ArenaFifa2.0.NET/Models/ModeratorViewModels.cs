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


    public class ChampionshipDetailsModel
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
        public int userID { get; set; }
        public int teamSofifaID { get; set; }
        public byte teamDeleted { get; set; }
        public byte hasImage { get; set; }
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

        [Required]
        [Display(Name = "PSN ID")]
        [StringLength(10, ErrorMessage = "O {0} deve ter no máximo {1} caracteres.")]
        public string psnID { get; set; }

        [Required]
        [Display(Name = "Nome Completo")]
        [StringLength(50, ErrorMessage = "O {0} deve ter no máximo {1} caracteres.")]
        public string name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "A {0} deve ter de {2} a no máximo {1} caracteres.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirma Senha")]
        [StringLength(10, ErrorMessage = "A {0} deve ter de {2} a no máximo {1} caracteres.", MinimumLength = 4)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "A Senha e a Confirmação da Senha não correspondem.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Nascimento")]
        public DateTime birthday { get; set; }
        public string birthdayFormatted { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public string state { get; set; }

        [Required]
        [Display(Name = "Como Soube?")]
        public string howfindus { get; set; }

        [Display(Name = "Qual?")]
        [StringLength(80, ErrorMessage = "O {0} deve ter no máximo {2} caracteres.")]
        public string whatkindofmedia { get; set; }

        [Required]
        [Display(Name = "Seu Time?")]
        public string team { get; set; }

        [Required]
        [Display(Name = "Modalidade que Deseja?")]
        public string yourmode { get; set; }

        [Display(Name = "Deseja Receber Email Alerta?")]
        public byte receiveWarningEachRound { get; set; }

        [Display(Name = "Deseja Receber Email Situação Campeonato?")]
        public byte receiveTeamTable { get; set; }

        [Display(Name = "Deseja Participar?")]
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
}
