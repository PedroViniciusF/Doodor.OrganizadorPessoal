using Doodor.OrganizadorPessoal.Domain.Events;
using System;

namespace Doodor.OrganizadorPessoal.Domain.Authentication.Events
{
    public class UsuarioRegistradoEvent : Event
    {
        public UsuarioRegistradoEvent(Guid id, string cpf)
        {
            Id = id;
            Cpf = cpf;
        }

        public Guid Id { get; private set; }
        public string Cpf { get; private set; }
    }
}
