using Doodor.OrganizadorPessoal.Domain.Financeiro.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Doodor.OrganizadorPessoal.Domain.Financeiro.Queries
{
    public class ContaQueries
    {
        //caso necessário também pode retornar uma query string para o repositorio
        //Retorna uma expressao link
        public static Expression<Func<Conta, bool>> GetConta(string nome)
        {
            return x => x.Nome == nome;
        }
    }
}
