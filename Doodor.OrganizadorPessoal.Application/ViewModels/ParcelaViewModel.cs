using System;
using System.ComponentModel.DataAnnotations;

namespace Doodor.OrganizadorPessoal.Application.ViewModels
{
    public class ParcelaViewModel
    {
        [Key]
        public Guid ContaId { get; set; }
        [Display(Name = "Nome da Conta")]
        public string NomeConta { get; set; }
        [Display(Name = "Numero da Parcela")]
        public int Numero { get; set; }
        [Display(Name = "Valor da Parcela")]
        public double Valor { get; set; }
        [Display(Name = "Parcela Paga")]
        public bool Pago { get; set; }
        [Display(Name = "Data Pgto da Parcela")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataParcela { get; set; }
        [Display(Name = "Data Parcela Paga")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataPgto { get; set; }
    }
}
