using Doodor.OrganizadorPessoal.Domain.Authentication;
using Doodor.OrganizadorPessoal.Domain.Authentication.Repository;
using Doodor.OrganizadorPessoal.Repo.SqlServer.Context;

namespace Doodor.OrganizadorPessoal.Repo.SqlServer.Repository
{
    public class UsuarioRepository : RepositoryBaseSqlServer<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ContasContext context) : base(context)
        {
        }
    }
}
