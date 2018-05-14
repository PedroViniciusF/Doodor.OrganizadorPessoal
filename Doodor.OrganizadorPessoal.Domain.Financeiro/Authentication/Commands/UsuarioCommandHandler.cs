using Doodor.OrganizadorPessoal.Domain.Authentication.Events;
using Doodor.OrganizadorPessoal.Domain.Authentication.Repository;
using Doodor.OrganizadorPessoal.Domain.Bus;
using Doodor.OrganizadorPessoal.Domain.Handlers;
using Doodor.OrganizadorPessoal.Domain.Notifications;
using Doodor.OrganizadorPessoal.Domain.Repository;
using System;
using System.Linq;

namespace Doodor.OrganizadorPessoal.Domain.Authentication.Commands
{
    public class UsuarioHandler : CommandHandler,
        IHandler<RegistrarUsuarioCommand>
    {
        private readonly IBus _bus;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioHandler(
            IUnitOfWork uow, 
            IBus bus, 
            IDomainNotificationHandler<DomainNotification> notifications,
            IUsuarioRepository usuarioRepository) : base(uow, bus, notifications)
        {
            _bus = bus;
            _usuarioRepository = usuarioRepository;
        }

        public void Handle(RegistrarUsuarioCommand message)
        {
            var usuario = new Usuario(message.Id, message.Cpf, message.Nome, message.Email);

            if (usuario.Invalid)
            {
                NotificarValidacoesErro(usuario.Notifications);
                return;
            }
            
            var usuarioExistente = _usuarioRepository.Find(x => x.Cpf == message.Cpf);

            if(usuarioExistente.Any())
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "CPF já utilizado"));
                return;
            }

            _usuarioRepository.Add(usuario);

            if (Commit())
            {
                _bus.RaiseEvent(new UsuarioRegistradoEvent(usuario.Id, usuario.Cpf));
            }
        }
    }
}
