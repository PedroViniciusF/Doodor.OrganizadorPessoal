using Doodor.OrganizadorPessoal.Domain.Events;
using Doodor.OrganizadorPessoal.Domain.Handlers;
using System.Collections.Generic;

namespace Doodor.OrganizadorPessoal.Domain.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message 
    {
        bool HasNotifications();
        List<T> GetNotifications();
    }
}
