﻿using System.ComponentModel.DataAnnotations;

namespace Doodor.OrganizadorPessoal.Infra.CrossCutting.Identity
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Lembrar-me?")]
        public bool RememberMe { get; set; }
    }
}
