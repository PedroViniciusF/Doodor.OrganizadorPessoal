using Doodor.OrganizadorPessoal.Application.ViewModels;

namespace Doodor.OrganizadorPessoal.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        void Registrar(UsuarioViewModel usuarioViewModel);
    }
}
