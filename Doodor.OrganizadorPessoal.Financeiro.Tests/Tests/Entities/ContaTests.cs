using Doodor.OrganizadorPessoal.Domain.Financeiro.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doodor.OrganizadorPessoal.Tests.Tests.Domain.Financeiro.Entities
{
    [TestClass]
    public class ContaTests
    {
        #region Properties
        private readonly Guid _usuarioId;
        private readonly string _nome;
        private readonly double _valorTotal;
        private readonly int _qtdParcelas;
        private readonly int _diaVencimento;        

        public static IEnumerable<object[]> _nomeGigante
        {
            get
            {
                return new[]
                  {
                    new object[]{ "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum" }
                };
            }
        }
        public static IEnumerable<object[]> _dataAtual
        {
            get
            {
                return new[]
                  {
                    new object[]{ DateTime.Now.ToString() }
                };
            }
        }
        #endregion

        public ContaTests()
        {
            _usuarioId = new Guid();
            _nome = "Pedro Vinicius Ferreira";
            _valorTotal = 100;
            _qtdParcelas = 2;
            _diaVencimento = 9;            
        }

        #region NomeInválido
        [TestMethod]
        //Cenário 01 - Nome grande demais
        [DynamicData("_nomeGigante")]
        [DataTestMethod]
        //Cenário 02 - Nome curto       
        [DataRow("eu")]
        //Cenário 03 - Nome vazio        
        [DataRow("")]
        //Cenário 04 - Nome com espaço
        [DataRow(" ")]
        //Cenário 05 - Nome com vários espaços
        [DataRow("         ")]
        public void RetornaErroCasoNomeInvalido(string nome)
        {
            var conta = new Conta(nome,_valorTotal, _qtdParcelas, _diaVencimento, _usuarioId);

            Assert.IsTrue(conta.Invalid);
        }
        #endregion
        #region NomeVálido
        [TestMethod]
        [DataTestMethod]
        [DataRow("Pedro Vinicius Ferreira")]//Nome válido     
        [DataRow("Pedro")]//Nome válido
        [DataRow("Pingo Gabriel")]//Nome válido
        public void RetornaErroCasoNomeValido(string nome)
        {
            var conta = new Conta(nome, _valorTotal, _qtdParcelas, _diaVencimento, _usuarioId);

            Assert.IsTrue(conta.Valid);
        }
        #endregion

        #region DiaVencimentoInválido
        [TestMethod]        
        [DataTestMethod]
        //Cenário 01 - Dia vencimento Zerado
        [DataRow(0)]
        //Cenário 02 - Dia vencimento grande demais
        [DataRow(32)]
        //Cenário 03 - Dia vencimento null
        [DataRow(null)]        
        public void RetornaErroCasoDiaVencimentoInvalido(int diaVencimento)
        {
            var conta = new Conta(_nome, _valorTotal, _qtdParcelas, diaVencimento, _usuarioId);

            Assert.IsTrue(conta.Invalid);
        }
        #endregion
        #region DiaVencimentoVálido
        [TestMethod]
        [DataTestMethod]
        //Cenário 01 - Ultimo dia vencimento valido
        [DataRow(31)]
        //Cenário 02 - Primeiro dia vencimento valido
        [DataRow(1)]
        public void RetornaSucessoCasoDiaVencimentoValido(int diaVencimento)
        {
            var conta = new Conta(_nome, _valorTotal, _qtdParcelas, diaVencimento, _usuarioId);

            Assert.IsTrue(conta.Valid);
        }
        #endregion

        #region QtdParcelasInválidas    
        [TestMethod]
        [DataTestMethod]
        //Cenário 01 - Qtd Parcelas zeradas
        [DataRow(0)]
        //Cenário 02 - Qtd Parcelas negativas
        [DataRow(-20)]
        public void RetornaErroCasoQtdParcelasInvalidas(int qtdParcela)
        {
            var conta = new Conta(_nome, _valorTotal, qtdParcela, _diaVencimento, _usuarioId);

            Assert.IsTrue(conta.Invalid);
        }
        #endregion 

        #region ParcelamentoInválido
        [TestMethod]
        public void RetornaErroCasoParcelamentoInvalido(int qtdParcelas)
        {
            var conta = new Conta(_nome, _valorTotal, qtdParcelas, _diaVencimento, _usuarioId);

            Assert.IsTrue(conta.Invalid);
        }
        #endregion
        #region ParcelamentoVálido
        [TestMethod]
        [DataTestMethod]
        public void RetornaSucessoCasoParcelamentoValido(int qtdParcelas)
        {
            var conta = new Conta(_nome, _valorTotal, qtdParcelas, _diaVencimento, _usuarioId);

            Assert.IsTrue(conta.Valid);
        }
        #endregion

        #region Pgto Conta Inválido
        [TestMethod]
        [DataTestMethod]
        //Cenário 01 - Valor pago negativo
        [DataRow(-1, 1)]
        //Cenário 02 - Valor pago parcela maior que o da conta
        [DataRow(150, 1)]
        //Cenário 03 - Menor parcela acima da ultima existente
        [DataRow(100, 3)]
        //Cenário 04 - Parcela negavita
        [DataRow(100, -1)]
        //Cenário 05 - Parcela zerada
        [DataRow(100, 0)]
        public void RetornaErroCasoPagamentoContaInvalido(double valorPago, int parcela)
        {
            var conta = new Conta(_nome, _valorTotal, _qtdParcelas, _diaVencimento, _usuarioId);

            //conta.PagarConta(valorPago, parcela);          

            Assert.IsTrue(conta.Invalid);
        }
        #endregion
        #region ParcelamentoVálido
        [TestMethod]
        [DataTestMethod]
        //Cenário 01 - Parcela pagamento correto
        [DataRow(100, 1)]
        //Cenário 02 - Parcela pagamento valor diferente do valor da parcela
        [DataRow(30, 1)]
        public void RetornaErroCasoPagamentoContaValido(double valorPago, int parcela)
        {
            var conta = new Conta(_nome, _valorTotal, _qtdParcelas, _diaVencimento, _usuarioId);

           // conta.PagarConta(valorPago, parcela);

            Assert.IsTrue(conta.Valid);
        }
        #endregion

        //TODO: Validacoes de criacao de parcelas
    }
}
