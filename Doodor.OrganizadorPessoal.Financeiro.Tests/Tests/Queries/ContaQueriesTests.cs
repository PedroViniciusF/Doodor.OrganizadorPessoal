using Doodor.OrganizadorPessoal.Domain.Financeiro.Entities;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Doodor.OrganizadorPessoal.Financeiro.Tests.Tests.Queries
{
    [TestClass]
    public class ContaQueriesTests
    {
        private IList<Conta> _contas;

        public ContaQueriesTests()
        {
            _contas = new List<Conta>();
            for (var i = 0; i<=10; i++)
            {                
                _contas.Add(new Conta($"carro-{i}", 100, 2, 9, Guid.NewGuid()));
            }
        }

        [TestMethod]
        public void RetornaNuloCasoContaNaoExista()
        {
            var exp = ContaQueries.GetConta("teste");
            var conta = _contas.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, conta);
        }

        [TestMethod]
        public void RetornaContaCasoExista()
        {
            var exp = ContaQueries.GetConta("carro-0");
            var conta = _contas.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(_contas[0], conta);
        }
    }
}
