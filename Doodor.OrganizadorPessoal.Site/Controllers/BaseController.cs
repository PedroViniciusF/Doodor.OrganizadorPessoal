using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doodor.OrganizadorPessoal.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Doodor.OrganizadorPessoal.Site.Controllers
{
    public class BaseController : Controller
    {
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;
        public BaseController(IDomainNotificationHandler<DomainNotification> notifications)
        {
            _notifications = notifications;
        }

        protected bool OperacaoValida()
        {
            return (!_notifications.HasNotifications());


        }
    }
}