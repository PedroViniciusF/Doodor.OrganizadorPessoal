using Doodor.OrganizadorPessoal.Domain.Commands;
using Doodor.OrganizadorPessoal.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doodor.OrganizadorPessoal.Domain.Bus
{
    public interface IBus
    {
        void SendCommand<T>(T theCommand) where T : Command;
        void RaiseEvent<T>(T theEvent) where T : Event;    
    }
}
