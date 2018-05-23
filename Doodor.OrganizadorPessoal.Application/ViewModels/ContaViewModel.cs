using Doodor.OrganizadorPessoal.Domain.Financeiro.Contas.ValueObjects.Conta;
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
        [Required(ErrorMessage = "Nome da Conta é requerido.")]
        [Display(Name = "Nome da Conta")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Valor total da conta")]
        public double ValorTotal { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataPrimeiroPgto { get; set; }
        [Required]
        public int QtdParcelas { get; set; }

        [Required]
        [Display(Name = "Frequencia pgto")]
        public int FrequenciaDiaPgto { get; set; }
        [Required]
        [Display(Name = "Porcentagem variacao mensal")]
        public int PorcVariacaoMensal { get; set; }

        public Guid UsuarioId { get; set; }

        public List<ParcelaViewModel> Parcelas { get; set; }

        public static SelectList GetSelectListFrequenciaPgto()
        {
            var parcelas = new List<object>() {
                new { FrequenciaDias = (int)FrequenciaPgtoVO.FrequenciaPgto.Semanal , Descricao = "Semanal(" + (int)FrequenciaPgtoVO.FrequenciaPgto.Semanal + ")" },
                new { FrequenciaDias = (int)FrequenciaPgtoVO.FrequenciaPgto.Quinzenal , Descricao = "Quinzenal(" + (int)FrequenciaPgtoVO.FrequenciaPgto.Quinzenal + ")" },
                new { FrequenciaDias = (int)FrequenciaPgtoVO.FrequenciaPgto.Mensal , Descricao = "Mensal(" + (int)FrequenciaPgtoVO.FrequenciaPgto.Mensal + ")" }
            };
            return new SelectList(parcelas, "FrequenciaDias", "Descricao");
        }
    }
}
