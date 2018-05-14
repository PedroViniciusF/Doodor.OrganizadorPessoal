using Doodor.OrganizadorPessoal.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doodor.OrganizadorPessoal.Domain.Authentication.Commands
{
    public class RegistrarUsuarioCommand : Command
    {
        public RegistrarUsuarioCommand(Guid id, string cpf, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Email = email;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
    }
}
