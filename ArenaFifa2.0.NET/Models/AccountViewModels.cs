using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ArenaFifa20.NET.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "PSN ID")]
        public string psnID { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string password { get; set; }

        public string actionUser { get; set; }
    }

    public class ChangePassWDViewModel
    {
        public string id { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha Atual")]
        [StringLength(10, ErrorMessage = "{0} não pode ser maior que {1}.")]
        public string current_password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha")]
        [StringLength(10, ErrorMessage = "{0} não pode ser maior que {1}.")]
        public string password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirma Senha")]
        [StringLength(10, ErrorMessage = "{0} não pode ser maior que {1}.")]
        [System.ComponentModel.DataAnnotations.Compare(nameof(password), ErrorMessage= "A Nova Senha e a Confirmação são diferentes.")]
        public string confirm_password { get; set; }

        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }


    public class returnJSON_UserLoginModel
    {
        public int id { get; set; }
        public string psnID { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string password20 { get; set; }
        public bool userActive { get; set; }
        public bool userModerator { get; set; }
        public string email { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy hh:mm:ss}")]
        public DateTime lastAccess { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        public DateTime birthday { get; set; }

        public string state { get; set; }
        public string howfindus { get; set; }
        public string whatkindofmedia { get; set; }
        public string team { get; set; }
        public byte receiveWarningEachRound { get; set; }
        public byte receiveTeamTable { get; set; }
        public byte wishParticipate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy hh:mm:ss}")]
        public DateTime register { get; set; }

        public string linkLiveMatch { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy hh:mm:ss}")]
        public DateTime lastUpdate { get; set; }

        public string psnIDLastUpdate { get; set; }
        public string passwordManager { get; set; }
        public string passwordManager20 { get; set; }
        public string workEmail { get; set; }
        public string codeArea { get; set; }
        public string mobileNumber { get; set; }
        public string returnMessage { get; set; }
        public string currentTeam { get; set; }
        public int totalTitlesWon { get; set; }
        public int totalVices { get; set; }
        public string pathAvatar { get; set; }
    }


    public class RegisterViewModel
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

        [Required]
        [Display(Name = "Estado")]
        public string state { get; set; }

        [Required]
        [Display(Name = "Como Soube?")]
        public string howfindus { get; set; }

        [Display(Name = "Qual?")]
        [StringLength(80, ErrorMessage = "O {0} deve ter no máximo {2} caracteres.")]
        public string whathowfindus { get; set; }

        [Required]
        [Display(Name = "Seu Time?")]
        public string team { get; set; }

        [Required]
        [Display(Name = "Modalidade que Deseja?")]
        public string yourmode { get; set; }

        [Display(Name = "Deseja Receber Email Alerta?")]
        public bool inEmailWarning { get; set; }

        [Display(Name = "Deseja Receber Email Situação Campeonato?")]
        public bool inEmailTeamTable { get; set; }

        [Display(Name = "Deseja Participar?")]
        public bool inParticipate { get; set; }

        public bool userActive { get; set; }
        public bool userModerator { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
        public string psnRegister { get; set; }
        public string psnOperation { get; set; }
        public int idUserOperation { get; set; }

        public IEnumerable<SelectListItem> listWhatHowFindUs { get; set; }
        public IEnumerable<SelectListItem> listStates { get; set; }
        public IEnumerable<SelectListItem> listTeams { get; set; }
        public IEnumerable<SelectListItem> listModes { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

}
