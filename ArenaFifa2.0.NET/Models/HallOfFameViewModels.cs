using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static ArenaFifa20.NET.App_Start.CustomValidators;

namespace ArenaFifa20.NET.Models
{
    public class BlackListViewModel
    {
        public int seasonID { get; set; }
        public int userID { get; set; }
        public int matchID { get; set; }
        public int championshipID { get; set; }
        public string psnID { get; set; }
        public string nameUser { get; set; }
        public string seasonName { get; set; }
        public List<BlackListSummary> listSummary { get; set; }
        public List<BlackListDetails> listDetails { get; set; }
        public string dtUpdateFormated { get; set; }
        public string messageBlackList { get; set; }
        public int valueBlackList { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class BlackListSummary
    {
        public int userID { get; set; }
        public string psnID { get; set; }
        public string nameUser { get; set; }
        public int noWarning { get; set; }
        public int noTotalOmission { get; set; }
        public int noPartialOmission { get; set; }
        public int noUnsportsmanlike { get; set; }
        public int total { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class BlackListDetails
    {
        public int championshipID { get; set; }
        public string championshipName { get; set; }
        public string stageName { get; set; }
        public string typeMode   { get; set; }
        public int roundID { get; set; }
        public int matchID { get; set; }
        public int noWarning { get; set; }
        public int noTotalOmission { get; set; }
        public int noPartialOmission { get; set; }
        public int noUnsportsmanlike { get; set; }
        public int valueBlackList { get; set; }
        public DateTime dtUpdate { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class HallOfFameSummaryViewModel
    {
        public string psnIDSerieAH2H { get; set; }
        public string teamIDSerieAH2H { get; set; }
        public string psnIDSerieAFUT { get; set; }
        public string teamIDSerieAFUT { get; set; }
        public string psnIDSerieAPRO { get; set; }
        public string teamIDSerieAPRO { get; set; }
        public string psnIDCDM { get; set; }
        public string teamIDCDM { get; set; }
        public string psnIDUCL { get; set; }
        public string teamIDUCL { get; set; }
        public string psnIDSCP { get; set; }
        public string teamIDSCP { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ChampionshipScoreViewModel
    {
        public List<ChampionshipTypeModel> listChampionshipScore { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ChampionshipTypeModel
    {
        public string championshipType { get; set; }
        public int scoreChampion { get; set; }
        public int scoreVice { get; set; }
        public int scoreSemi { get; set; }
        public int scoreQuarter { get; set; }
        public int scoreRound16 { get; set; }
        public int scoreQualifyNextStage { get; set; }
        public int score2ndStage { get; set; }
        public int scoreWins { get; set; }
        public int scoreDraws { get; set; }
    }

    public class GeneralBlackListViewModel
    {
        public List<GeneralBlackListModel> listBlackList { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class GeneralBlackListModel
    {
        public string psnID { get; set; }
        public string userName { get; set; }
        public int total { get; set; }
        public int totalPreviousSeason { get; set; }
    }


    public class AchievementViewModel
    {
        public List<AchievementModel> listOfAchievement { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class AchievementModel
    {
        public string championshipType { get; set; }
        public Boolean inGroup { get; set; }
        public string userName { get; set; }
        public string seasonName { get; set; }
        public string teamName { get; set; }
    }

    public class RenewalViewModel
    {
        public List<RenewalChampionshipModel> listOfRenewal { get; set; }
        public int previousSeasonID { get; set; }
        public int seasonID { get; set; }
        public string seasonName { get; set; }
        public string previousSeasonName { get; set; }
        public string renewalMode { get; set; }
        public string championshipIDRenewal { get; set; }
        public string championshipIDBenchRenewal { get; set; }
        public string championshipIDRenewalWorldCupUefaEuro { get; set; }
        public int totalApprovedRenewal { get; set; }
        public int totalUnderAnalysisRenewal { get; set; }
        public int totalLimitBlackList { get; set; }
        public int totalLimitBanWorldCupUefaEuro { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class RenewalChampionshipModel
    {
        public int championshipID { get; set; }
        public int userID { get; set; }
        public string userName { get; set; }
        public string psnID { get; set; }
        public string teamName { get; set; }
        public string status { get; set; }
        public string statusInitials { get; set; }
        public int seasonCurrentTotal { get; set; }
        public int total { get; set; }
        public int grandTotal { get; set; }
        public int playersTotal { get; set; }
        public int blackListtotal { get; set; }
        public string acceptedRenewal { get; set; }
        public string actionRenewal { get; set; }
    }

    public class RenewalPROCLUBSquadViewModel
    {
        public List<RenewalSquadModel> listOfSquad { get; set; }
        public int managerID { get; set; }
        public string mangerName { get; set; }
        public string psnID { get; set; }
        public int seasonID { get; set; }
        public string clubName { get; set; }
        public string pathImageClub { get; set; }
        public string mobileNumber { get; set; }
        public string codeMobileNumber { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
}

public class RenewalSquadModel
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public string psnID { get; set; }
        public string recordDate { get; set; }
        public Boolean isCapitain { get; set; }
    }



}
