using Doodor.OrganizadorPessoal.Domain.Financeiro.Entities;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Repositories;
using Doodor.OrganizadorPessoal.Domain.Financeiro.ValueObjects;
using Doodor.OrganizadorPessoal.Repo.SqlServer.Context;
using Doodor.OrganizadorPessoal.Repo.SqlServer.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Doodor.OrganizadorPessoal.Repository.Repositories
{
    public class ContaRepository : RepositoryBaseSqlServer<Conta>, IContaRepository
    {        
        public ContaRepository(ContasContext context) : base(context)
        {            
        }

        public override Conta FindById(Guid id)
        {
            var conta = DbSet
                .Include(x => x.Parcelas)
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            conta.Parcelas = conta.Parcelas.OrderBy(x => x.DataParcela).ToList();

            return conta;                   
        }

        public bool NomeContaExiste(string nome)
        {
            var conta = base.Find(x => x.Nome == nome);

            return conta.Count > 0;
        }

        public void CriarConta(Conta conta)
        {
            base.Add(conta);
        }

        public void AtualizarConta(Conta conta)
        {       
            foreach(var parcela in conta.Parcelas)
            {
                Db.Parcelas.Add(parcela);
            }

            base.Update(conta);
        }
     
        public void DeletarConta(Guid id)
        {
            base.Remove(id);
        }

        public void DeletarParcelasConta(Guid id)
        {
            var parcelas = Db.Parcelas.Where(x => x.ContaId == id);

            foreach(var parcela in parcelas)
            {
                Db.Parcelas.Remove(parcela);
            }
        }  
    }
}
