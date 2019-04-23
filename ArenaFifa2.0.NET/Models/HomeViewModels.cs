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

    public class BenchModesViewModel
    {
        public List<BenchModes> listBench { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class BenchModes
    {
        public int id { get; set; }
        public int userID { get; set; }
        public string psnID { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public string team { get; set; }
        public string typeBench { get; set; }
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

    public class SeasonDetails
    {
        public int id { get; set; }
        public string name { get; set; }
        public byte active { get; set; }
        public DateTime dtStartSeason { get; set; }
        public DateTime dtEndSeason { get; set; }
        public string typeMode { get; set; }
        public string returnMessage { get; set; }
    }



}
