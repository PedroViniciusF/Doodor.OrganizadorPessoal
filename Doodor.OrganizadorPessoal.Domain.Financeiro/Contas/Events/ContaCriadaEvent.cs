using Doodor.OrganizadorPessoal.Domain.Events;
using System;

namespace Doodor.OrganizadorPessoal.Domain.Financeiro.Contas.Events
{
    public class ContaCriadaEvent : Event
    {
        public ContaCriadaEvent(Guid id, string nome, double valorTotal, bool pago, int qtdParcelas, DateTime dataPgto, bool parcelado, DateTime diaPrimeiroPgto, int frequenciaDiaPgto, int porcVariacaoMensal)
        {
            Id = id;
            Nome = nome;
            ValorTotal = valorTotal;
            Pago = pago;
            QtdParcelas = qtdParcelas;
            DataPgto = dataPgto;
            Parcelado = parcelado;
            DiaPrimeiroPgto = diaPrimeiroPgto;
            FrequenciaDiaPgto = frequenciaDiaPgto;
            PorcVariacaoMensal = porcVariacaoMensal;

            AggregateId = id;
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public double ValorTotal { get; set; }
        public bool Pago { get; set; }
        public int QtdParcelas { get; set; }
        public DateTime DataPgto { get; set; }
        public bool Parcelado { get; set; }
        public DateTime DiaPrimeiroPgto { get; set; }
        public int FrequenciaDiaPgto { get; set; }
        public int PorcVariacaoMensal { get; set; }
    }
}
