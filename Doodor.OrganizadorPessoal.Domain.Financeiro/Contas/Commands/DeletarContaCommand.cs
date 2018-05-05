using Doodor.OrganizadorPessoal.Domain.Commands;
using System;

namespace Doodor.OrganizadorPessoal.Domain.Financeiro.Contas.Commands
{
    public class DeletarContaCommand : Command
    {
        public DeletarContaCommand(Guid id)
        {
            Id = id;

            AggregateId = id;
        }
        public Guid Id { get; set; }
    }
}
