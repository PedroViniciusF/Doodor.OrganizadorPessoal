using Doodor.OrganizadorPessoal.Domain.Financeiro.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doodor.OrganizadorPessoal.Financeiro.Tests.Mocks
{
    public class FakeEmailService : IEmailService
    {
        public void Enviar(string para, string email, string assunto, string corpo)
        {
            
        }
    }
}
