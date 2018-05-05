using System;
using System.Collections.Generic;
using System.Text;

namespace Doodor.OrganizadorPessoal.Domain.Financeiro.Services
{
    public interface IEmailService
    {
        void Enviar(string para, string email, string assunto, string corpo);
    }
}
