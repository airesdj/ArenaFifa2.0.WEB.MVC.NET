using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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


}
