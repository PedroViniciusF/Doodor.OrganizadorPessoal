using Dapper;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Authentication.Interfaces;
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
        IUser _user { get; set; }
        public ContaRepository(ContasContext context, IUser user) : base(context)
        {
            _user = user;
        }

        public override ICollection<Conta> FindAll()
        {
            var sql = "SELECT * FROM CONTAS C "+
                      "WHERE C.EXCLUIDO = 0 " +
                      "ORDER BY C.DATACADASTRO DESC";
            return Db.Database.GetDbConnection().Query<Conta>(sql).ToList();
        }

        public override Conta FindById(Guid id)
        {
            var sql = @"SELECT * FROM CONTAS C " +
                      "INNER JOIN PARCELAS P ON C.Id= P.ContaId " +
                      "WHERE C.EXCLUIDO = 0 AND C.Id = @uid " +
                      "ORDER BY P.DATAPARCELA";

            Conta conta = new Conta();
            List<Parcela> parcelas = new List<Parcela>();
            var contaQuery = Db.Database.GetDbConnection().Query<Conta, Parcela, Conta>(sql, (c, p) =>
            {
                conta = c;
                parcelas.Add(p);              

                return c;
            }, new { uid = id });

            conta.Parcelas = parcelas;
            return conta;                   
        }

        public bool NomeContaExiste(string nome)
        {            
            var sql = @"SELECT * FROM CONTAS C WHERE C.NOME = @nome";

            if (_user.GetUserId() != null)
                sql += " and usuarioid = @usuarioid;";

            var conta = Db.Database.GetDbConnection().Query<Conta>(sql, new { nome = nome, usuarioid = _user.GetUserId() }).FirstOrDefault();            

            return conta != null;
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
