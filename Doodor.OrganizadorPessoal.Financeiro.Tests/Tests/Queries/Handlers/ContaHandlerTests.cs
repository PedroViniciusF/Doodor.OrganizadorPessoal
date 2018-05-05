using Doodor.OrganizadorPessoal.Domain.Financeiro.CommandHandlers;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Commands;
using Doodor.OrganizadorPessoal.Financeiro.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doodor.OrganizadorPessoal.Tests.Tests.Domain.Financeiro.Handlers
{
    [TestClass]
    public class ContaHandlerTests
    {
        [TestMethod]
        public void RetornaErroCasoNomeContaJaExiste()
        {
            //var handler = new ContaHandler(
            //    new FakeContaRepository(), new FakeEmailService(),new FakeIowRepository(), new FakeBusRepository(), new FakeDomainNotificationHanlder());

            //var command = new CriarContaCommand();
            //command.Nome = "carro";
            //command.ValorTotal = 100;
            //command.Pago = false;
            //command.QtdParcelas = 1;
            //command.DataPgto = DateTime.Now.AddDays(30);
            //command.Parcelado = false;
            //command.DiaVencimento = 10;

            //var result = handler.Handle(command);

            //Assert.IsTrue(result.Sucess);
        }
    }
}
