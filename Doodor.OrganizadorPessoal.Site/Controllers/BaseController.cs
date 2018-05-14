using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Authentication.Interfaces;
using Doodor.OrganizadorPessoal.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Doodor.OrganizadorPessoal.Site.Controllers
{
    public class BaseController : Controller
    {
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;
        private readonly IUser _user;

        public Guid UsuarioId { get; set; }

        public BaseController(IDomainNotificationHandler<DomainNotification> notifications,
            IUser user)
        {
            _notifications = notifications;
            _user = user;

            if (_user.IsAuthenticated())
            {
                UsuarioId = _user.GetUserId();
            }
        }

        protected bool OperacaoValida()
        {
            return (!_notifications.HasNotifications());
        }
    }
}