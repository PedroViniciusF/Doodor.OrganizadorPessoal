using Doodor.OrganizadorPessoal.Domain.Events;
using System;
namespace Doodor.OrganizadorPessoal.Domain.Financeiro.Contas.Events
{
    public class ContaDeletadaEvent : Event
    {       
        public ContaDeletadaEvent(Guid id, string nome)
        {
            Id = id;
            Nome = nome;

            AggregateId = id;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
    }
}
