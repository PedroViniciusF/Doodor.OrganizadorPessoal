using System.ComponentModel.DataAnnotations;

namespace Doodor.OrganizadorPessoal.Site.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "{0} é requerido")]
        [StringLength(50, ErrorMessage = "O {0} deve conter no máximo {2} caracteres, e no mínimo {1}", MinimumLength = 4)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} é requerido")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} é requerido")]
        [StringLength(11, ErrorMessage = "CPF deve conter 11 caracteres")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "{0} é requerida")]
        [StringLength(100, ErrorMessage = "A {0} deve conter no máximo {2} caracteres, e no mínimo {1}", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Cofirmar Senha")]
        [Compare("Password", ErrorMessage = "A confirmação e a senha devem ser iguais")]
        public string ConfirmPassword { get; set; }
    }
}
