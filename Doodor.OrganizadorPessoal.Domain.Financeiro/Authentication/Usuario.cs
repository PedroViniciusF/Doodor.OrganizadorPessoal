using Doodor.OrganizadorPessoal.Domain.Entities;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Entities;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doodor.OrganizadorPessoal.Domain.Authentication
{
    public class Usuario : Entity
    {
        private Usuario(){}
        public Usuario(Guid id, string cpf, string nome, string email)
        {           
            ValidateDefault(cpf);
            if (Valid)
            {
                Id = id;
                Cpf = cpf;
                Nome = nome;
                Email = email;
            }
        }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }

        public virtual ICollection<Conta> Contas { get; set; }
        #region Validates
        private void ValidateDefault(string cpf)
        {
            //notificações validão o que tem que ser.
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(cpf, "Usuario.Cpf", "CPF não pode ser nulo nem em branco")
                .HasLen(cpf, 11, "Usuario.Cpf", "CPF deve conter 11 caracteres")               
                .IsTrue(!string.IsNullOrWhiteSpace(cpf), "Usuario.Cpf", "CPF não pode ser preenchido só por espaços")              
                );
        }
        #endregion
    }
}
