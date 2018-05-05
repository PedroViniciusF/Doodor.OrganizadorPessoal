using Doodor.OrganizadorPessoal.Domain.Bus;
using Doodor.OrganizadorPessoal.Domain.Commands;
using Doodor.OrganizadorPessoal.Domain.Events;
using Doodor.OrganizadorPessoal.Domain.Handlers;
using Doodor.OrganizadorPessoal.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doodor.OrganizadorPessoal.CrossCutting.Bus
{
    //sealed significa que a classe não pode ser herdada por ninguém
    public sealed class InMemoryBus : IBus
    {
        public static Func<IServiceProvider> ContainerAccessor { get; set; }

        private static IServiceProvider Container => ContainerAccessor(); 

        public void RaiseEvent<T>(T theEvent) where T : Event
        {
            Publish(theEvent);
        }

        public void SendCommand<T>(T theCommand) where T : Command
        {
            Publish(theCommand);
        }

        private static void Publish<T>(T message) where T : Message
        {
            if (Container == null) return;

            var obj = Container.GetService(message.MessageType.Equals("DomainNotification")
                ? typeof(IDomainNotificationHandler<T>)
                : typeof(IHandler<T>));

            ((IHandler<T>)obj).Handle(message);
        }
    }
}
