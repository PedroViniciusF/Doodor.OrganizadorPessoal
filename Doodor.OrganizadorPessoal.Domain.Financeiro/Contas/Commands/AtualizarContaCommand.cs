using Doodor.OrganizadorPessoal.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doodor.OrganizadorPessoal.Domain.Financeiro.Contas.Commands
{  
    public class AtualizarContaCommand : Command
    {
        public AtualizarContaCommand(Guid id, string nome, double valorTotal, int qtdParcelas, int diaVencimento, Guid usuarioId)
        {
            Id = id;
            Nome = nome;
            ValorTotal = valorTotal;
            QtdParcelas = qtdParcelas;
            DiaVencimento = diaVencimento;


            AggregateId = id;
        }
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public double ValorTotal { get; private set; }
        public int QtdParcelas { get; private set; }
        public int DiaVencimento { get; private set; }
        public Guid UsuarioId { get; private set; }
    }
}
