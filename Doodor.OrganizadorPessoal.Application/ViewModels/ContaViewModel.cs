using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Doodor.OrganizadorPessoal.Application.ViewModels
{
    public class ContaViewModel
    {
        public ContaViewModel()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Nome da Conta")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Valor total da conta")]
        public double ValorTotal { get; set; }
        [Required]
        [Display(Name = "Dia vencimento da conta")]
        public int DiaVencimento { get; set; }
        [Required]
        public int QtdParcelas { get; set; }
        public List<ParcelaViewModel> Parcelas { get; set; }

        public static SelectList GetSelectListParcelas()
        {
            var parcelas = new List<ParcelaViewModel>() {
                new ParcelaViewModel(){ Numero = 1 },
                new ParcelaViewModel(){ Numero = 2 },
                new ParcelaViewModel(){ Numero = 3 },
                new ParcelaViewModel(){ Numero = 4 },
                new ParcelaViewModel(){ Numero = 5 },
                new ParcelaViewModel(){ Numero = 6 },
                new ParcelaViewModel(){ Numero = 7 },
                new ParcelaViewModel(){ Numero = 8 },
                new ParcelaViewModel(){ Numero = 9 },
                new ParcelaViewModel(){ Numero = 10 }
            };
            return new SelectList(parcelas, "Numero", "Numero");
        }
    }
}
