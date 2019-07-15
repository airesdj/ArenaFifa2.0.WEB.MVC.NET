using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static ArenaFifa20.NET.App_Start.CustomValidators;

namespace ArenaFifa20.NET.Models
{
    public class ContactUsViewModel
    {
        [Required]
        [Display(Name = "PSN ID")]
        public string psnID { get; set; }

        [Required]
        [Display(Name = "Nome Completo")]
        public string name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Título do Email")]
        public string subject { get; set; }

        [Required]
        [Display(Name = "Mensagem")]
        public string message { get; set; }
    }

    public class HomePageViewModel
    {
        public int seasonID { get; set; }
        public string seasonName { get; set; }
        public int seasonID_FUT { get; set; }
        public string seasonName_FUT { get; set; }
        public int seasonID_PRO { get; set; }
        public string seasonName_PRO { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class SubscribeBench
    {
        public int id { get; set; }
        public bool checkH2H { get; set; }
        public bool checkFUT { get; set; }
        public bool checkPRO { get; set; }

        [Display(Name = "Nome Time FUT")]
        [RequiredIf("checkFUT", true, ErrorMessage = "O nome do time FUT deve ser informado.")]
        [StringLength(50, ErrorMessage = "{0} não pode ser maior que {1}.")]
        public string teamNameFUT { get; set; }

        [Display(Name = "Nome Time PRO Club")]
        [RequiredIf("checkPRO", true, ErrorMessage = "O nome do time PRO CLUB deve ser informado.")]
        [StringLength(50, ErrorMessage = "{0} não pode ser maior que {1}.")]
        public string teamNamePRO { get; set; }

        [Display(Name = "DDD")]
        [DataType(DataType.PhoneNumber)]
        [Range(0, 99, ErrorMessage = "Número de DDD inválido.")]
        [RequiredIf("checkPRO", true, ErrorMessage = "O número do DDD deve ser informado.")]
        public string ddd { get; set; }

        [Display(Name = "Celular")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15, ErrorMessage = "{0} não pode ser maior que {1}.")]
        [Phone()]
        [RequiredIf("checkPRO", true, ErrorMessage = "O número do celular deve ser informado.")]
        public string mobile { get; set; }

        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class GenerateRenewalViewModel
    {
        public int seasonH2HID { get; set; }
        public string seasonH2HName { get; set; }
        public int seasonFUTID { get; set; }
        public string seasonFUTName { get; set; }
        public int seasonPROID { get; set; }
        public string seasonPROName { get; set; }
        public int totalUsersBcoOnLine { get; set; }
        public int totalUsersBcoStaging { get; set; }
        public int lastSeasonH2HID { get; set; }
        public string lastSeasonH2HName { get; set; }
        public int lastSeasonFUTID { get; set; }
        public string lastSeasonFUTName { get; set; }
        public int lastSeasonPROID { get; set; }
        public string lastSeasonPROName { get; set; }
        public string dataBaseName { get; set; }
        public int inRenewalWithWorldCup { get; set; }
        public int inRenewalWithEuro { get; set; }
        public Boolean databaseStagingPrepared { get; set; }
        public Boolean renewalNewSeasonGenerated { get; set; }
        public Boolean emailsSent { get; set; }
        public int totalUserRenewalForNextSeason { get; set; }
        public int totalEmailSpoolerForRenewal { get; set; }
        public int userActionID { get; set; }
        public renewalDetailsModel renewalModel { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class renewalDetailsModel
    {
        public int seasonID { get; set; }
        public int userID { get; set; }
        public string userName { get; set; }
        public string psnID { get; set; }
        public Boolean checkYESH2H { get; set; }
        public Boolean checkNOH2H { get; set; }
        public Boolean checkYESFUT { get; set; }
        public Boolean checkNOFUT { get; set; }
        public Boolean checkYESPRO { get; set; }
        public Boolean checkNOPRO { get; set; }
        public Boolean checkYESWDC { get; set; }
        public Boolean checkNOWDC { get; set; }

        [Display(Name = "Nome Time FUT")]
        [RequiredIf("checkYESFUT", true, ErrorMessage = "O nome do time FUT deve ser informado.")]
        [StringLength(50, ErrorMessage = "{0} não pode ser maior que {1}.")]
        public string teamNameFUT { get; set; }

        [Display(Name = "Nome Time PRO Club")]
        [RequiredIf("checkYESPRO", true, ErrorMessage = "O nome do time PRO CLUB deve ser informado.")]
        [StringLength(50, ErrorMessage = "{0} não pode ser maior que {1}.")]
        public string teamNamePRO { get; set; }

        [Display(Name = "DDD")]
        [DataType(DataType.PhoneNumber)]
        [Range(0, 99, ErrorMessage = "Número de DDD inválido.")]
        [RequiredIf("checkYESPRO", true, ErrorMessage = "O número do DDD deve ser informado.")]
        public string ddd { get; set; }

        [Display(Name = "Celular")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15, ErrorMessage = "{0} não pode ser maior que {1}.")]
        [Phone()]
        [RequiredIf("checkYESPRO", true, ErrorMessage = "O número do celular deve ser informado.")]
        public string mobile { get; set; }

        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class RankingSupportersModel
    {
        public List<SupportesTeamModel> listSupportesTeam { get; set; }
        public string dtUpdateFormated { get; set; }
        public int totalUser { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class SupportesTeamModel
    {
        public string teamName { get; set; }
        public int total { get; set; }
    }

}
