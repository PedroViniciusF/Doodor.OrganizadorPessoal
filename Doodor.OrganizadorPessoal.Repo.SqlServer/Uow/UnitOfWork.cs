using Doodor.OrganizadorPessoal.Domain.Commands;
using Doodor.OrganizadorPessoal.Domain.Repository;
using Doodor.OrganizadorPessoal.Repo.SqlServer.Context;

namespace Doodor.OrganizadorPessoal.Repo.SqlServer.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContasContext _context;

        public UnitOfWork(ContasContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
