using Doodor.OrganizadorPessoal.Domain.Events;
using System;

namespace Doodor.OrganizadorPessoal.Domain.Financeiro.Contas.Events
{
    public class ContaCriadaEvent : Event
    {
        public ContaCriadaEvent(Guid id, string nome, double valorTotal, bool pago, int qtdParcelas, DateTime dataPgto, bool parcelado, int diaVencimento)
        {
            Id = id;
            Nome = nome;
            ValorTotal = valorTotal;
            Pago = pago;
            QtdParcelas = qtdParcelas;
            DataPgto = dataPgto;
            Parcelado = parcelado;
            DiaVencimento = diaVencimento;

            AggregateId = id;
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public double ValorTotal { get; set; }
        public bool Pago { get; set; }
        public int QtdParcelas { get; set; }
        public DateTime DataPgto { get; set; }
        public bool Parcelado { get; set; }
        public int DiaVencimento { get; set; }
    }
}
