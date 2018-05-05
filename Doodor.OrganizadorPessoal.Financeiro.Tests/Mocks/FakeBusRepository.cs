using Doodor.OrganizadorPessoal.Domain.Bus;
using Doodor.OrganizadorPessoal.Domain.Commands;
using Doodor.OrganizadorPessoal.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doodor.OrganizadorPessoal.Financeiro.Tests.Mocks
{
    public class FakeBusRepository : IBus
    {
        public void RaiseEvent<T>(T theEvent) where T : Event
        {
            throw new NotImplementedException();
        }

        public void SendCommand<T>(T theCommand) where T : Command
        {
            throw new NotImplementedException();
        }
    }
}
