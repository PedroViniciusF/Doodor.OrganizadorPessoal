using AutoMapper;
using Doodor.OrganizadorPessoal.Application.Interfaces;
using Doodor.OrganizadorPessoal.Application.ViewModels;
using Doodor.OrganizadorPessoal.Domain.Authentication.Commands;
using Doodor.OrganizadorPessoal.Domain.Authentication.Repository;
using Doodor.OrganizadorPessoal.Domain.Bus;

namespace Doodor.OrganizadorPessoal.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private IMapper _mapper { get; set; }
        private IUsuarioRepository _usuarioRepository { get; set; }
        private IBus _bus { get; set; }

        public UsuarioAppService(
            IMapper mapper, 
            IUsuarioRepository usuarioRepository,
            IBus bus)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _bus = bus;
        }

        public void Registrar(UsuarioViewModel usuarioViewModel)
        {
            var registroCommand = _mapper.Map<RegistrarUsuarioCommand>(usuarioViewModel);

            _bus.SendCommand(registroCommand);
        }
        public void Dispose()
        {

        }
    }
}
