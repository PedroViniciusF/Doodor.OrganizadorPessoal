using Doodor.OrganizadorPessoal.Domain.Commands;
using System;


namespace Doodor.OrganizadorPessoal.Domain.Financeiro.Commands
{
    public class CriarContaCommand : Command
    {
        public CriarContaCommand(Guid aggregateId, string nome, double valorTotal, int qtdParcelas, DateTime diaPrimeiroPgto, int frequenciaDiaPgto, int porcVariacaoMensal, Guid usuarioId)
        {
            Nome = nome;
            ValorTotal = valorTotal;            
            QtdParcelas = qtdParcelas;
            DiaPrimeiroPgto = diaPrimeiroPgto;
            UsuarioId = usuarioId;
            FrequenciaDiaPgto = frequenciaDiaPgto;
            PorcVariacaoMensal = porcVariacaoMensal;

           AggregateId = aggregateId;
        }
        public string Nome { get; private set; }
        public double ValorTotal { get; private set; }        
        public int QtdParcelas { get; private set; }
        public DateTime DiaPrimeiroPgto { get; private set; }
        public int FrequenciaDiaPgto { get; private set; }
        public int PorcVariacaoMensal { get; private set; }
        public Guid UsuarioId { get; private set; }
    }
}
