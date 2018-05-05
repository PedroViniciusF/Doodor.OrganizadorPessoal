using Doodor.OrganizadorPessoal.Domain.Commands;
using System;

namespace Doodor.OrganizadorPessoal.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
