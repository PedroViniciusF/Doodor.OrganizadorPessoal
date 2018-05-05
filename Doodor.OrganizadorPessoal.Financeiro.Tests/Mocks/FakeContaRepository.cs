using System;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Entities;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Repositories;

namespace Doodor.OrganizadorPessoal.Financeiro.Tests.Mocks
{
    public class FakeContaRepository : FakeRepositoryBaseSqlServer<Conta>, IContaRepository
    {
        public void AtualizarConta(Conta conta)
        {
            throw new NotImplementedException();
        }

        public void CriarConta(Conta conta)
        {
            
        }

        public void DeletarConta(Guid id)
        {
            throw new NotImplementedException();
        }

        public void DeletarParcelasConta(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool NomeContaExiste(string nome)
        {
            if (nome == "carro")
                return true;

            return false;
        }
    }
}
