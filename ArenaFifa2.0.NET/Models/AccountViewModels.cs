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

    public class returnJSON_UserLoginModel
    {
        public int id { get; set; }
        public string psnID { get; set; }
        public string password { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }




    public class RegisterViewModel
    {
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
        [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} caracteres.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirma Senha")]
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

        [Required]
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

        public IEnumerable<SelectListItem> listWhatHowFindUs { get; set; }
        public IEnumerable<SelectListItem> listStates { get; set; }
        public IEnumerable<SelectListItem> listTeams { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

}
