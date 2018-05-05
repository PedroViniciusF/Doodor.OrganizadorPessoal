using Doodor.OrganizadorPessoal.Domain.Bus;using Doodor.OrganizadorPessoal.Domain.Notifications;
using Doodor.OrganizadorPessoal.Domain.Repository;
using Flunt.Notifications;
using System;
using System.Collections.Generic;

namespace Doodor.OrganizadorPessoal.Domain.Handlers
{
    public class CommandHandler
    {
        private IUnitOfWork _uow;
        private IBus _bus;
        private IDomainNotificationHandler<DomainNotification> _notifications;

        public CommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _bus = bus;
            _notifications = notifications;
        }

        protected void NotificarValidacoesErro(IReadOnlyCollection<Notification> notifications)
        {
            foreach (var erro in notifications)
            {                 
                _bus.RaiseEvent(new DomainNotification(erro.Property, erro.Message));
            }
        }

        protected bool Commit()
        {
            if (_notifications.HasNotifications()) return false;

            var commandResponse = _uow.Commit();
            if (commandResponse.Success) return true;            

            Console.WriteLine("Ocorreu um erro ao salvar os dados no banco");
            _bus.RaiseEvent(new DomainNotification("Commit", "Ocorreu um erro ao salvar os dados no banco"));
            return false;
        }


    }
}
