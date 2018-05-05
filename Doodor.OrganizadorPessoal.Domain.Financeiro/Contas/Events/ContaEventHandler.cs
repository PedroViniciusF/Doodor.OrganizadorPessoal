using Doodor.OrganizadorPessoal.Domain.Financeiro.Commands;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Contas.Events;
using Doodor.OrganizadorPessoal.Domain.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doodor.OrganizadorPessoal.Domain.Financeiro.Contas.Events
{
    public class ContaEventHandler :
        IHandler<ContaCriadaEvent>,
        IHandler<ContaAtualizadaEvent>,
        IHandler<ContaDeletadaEvent>
    {
        public void Handle(ContaCriadaEvent message)
        {
            //enviar um e-mail
            //logar informacao            
        }

        public void Handle(ContaAtualizadaEvent message)
        {            
        }

        public void Handle(ContaDeletadaEvent message)
        {            
        }
    }
}
