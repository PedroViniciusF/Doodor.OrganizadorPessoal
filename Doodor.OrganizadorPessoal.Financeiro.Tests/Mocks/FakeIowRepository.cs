using Doodor.OrganizadorPessoal.Domain.Commands;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Commands;
using Doodor.OrganizadorPessoal.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doodor.OrganizadorPessoal.Financeiro.Tests.Mocks
{
    public class FakeIowRepository : IUnitOfWork
    {
        public CommandResponse Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
