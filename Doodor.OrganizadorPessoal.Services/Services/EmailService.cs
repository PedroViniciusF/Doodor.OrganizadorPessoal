using Doodor.OrganizadorPessoal.Domain.Financeiro.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doodor.OrganizadorPessoal.Services.Services
{
    public class EmailService : IEmailService
    {
        public void Enviar(string para, string email, string assunto, string corpo)
        {
            Console.WriteLine("Enviei o e-mail");
        }
    }
}
