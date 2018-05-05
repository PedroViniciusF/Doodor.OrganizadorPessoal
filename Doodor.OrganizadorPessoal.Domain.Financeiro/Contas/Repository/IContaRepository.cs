using Doodor.OrganizadorPessoal.Domain.Financeiro.Entities;
using Doodor.OrganizadorPessoal.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doodor.OrganizadorPessoal.Domain.Financeiro.Repositories
{
    public interface IContaRepository : IRepositoryBaseSqlServer<Conta>
    {        
        bool NomeContaExiste(string nome);
        void CriarConta(Conta conta);
        void AtualizarConta(Conta conta);
        void DeletarConta(Guid id);
        void DeletarParcelasConta(Guid id);
    }
}
