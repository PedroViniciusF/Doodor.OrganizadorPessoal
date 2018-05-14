using Doodor.OrganizadorPessoal.Domain.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doodor.OrganizadorPessoal.Domain.Authentication.Events
{
    public class UsuarioEventHandler : IHandler<UsuarioRegistradoEvent>
    {
        public void Handle(UsuarioRegistradoEvent message)
        {
            //TODO: Enviar e-mail
        }
    }
}
