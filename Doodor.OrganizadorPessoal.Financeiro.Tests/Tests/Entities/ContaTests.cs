using Doodor.OrganizadorPessoal.Domain.Financeiro.Entities;
using Doodor.OrganizadorPessoal.Domain.Financeiro.ValueObjects;
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
        private readonly DateTime _dataPrimeiroPgto;
        private readonly int _frequenciaPgto;
        private readonly int _porcVariacaoMensal;

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
        public static IEnumerable<object[]> _maiorDataNaoAceita
        {
            get
            {
                return new[]
                  {
                    new object[]{ new DateTime(1000,01,01) }
                };
            }
        }

        //datas test primeiro pgto
        public static IEnumerable<object[]> _primeiroPgto1MesAFrente
        {
            get
            {
                return new[]
                  {
                    new object[]{ DateTime.Now.AddMonths(1) }
                };
            }
        }
        public static IEnumerable<object[]> _primeiroPgto2MesesATras
        {
            get
            {
                return new[]
                  {
                    new object[]{ DateTime.Now.AddMonths(-2) }
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
            _dataPrimeiroPgto = new DateTime(2018,05,01);
            _frequenciaPgto = 30;
            _porcVariacaoMensal = 0;
        }

        #region ValidaçõesNomeInválido
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
            var conta = new Conta(nome,_valorTotal, _qtdParcelas, _dataPrimeiroPgto, _frequenciaPgto, _porcVariacaoMensal, _usuarioId);

            Assert.IsTrue(conta.Invalid);
        }
        #endregion
        #region ValidaçõesNomeVálido
        [TestMethod]
        [DataTestMethod]
        [DataRow("Pedro Vinicius Ferreira")]//Nome válido     
        [DataRow("Pedro")]//Nome válido
        [DataRow("Pingo Gabriel")]//Nome válido
        public void RetornaErroCasoNomeValido(string nome)
        {
            var conta = new Conta(nome, _valorTotal, _qtdParcelas, _dataPrimeiroPgto, _frequenciaPgto, _porcVariacaoMensal, _usuarioId);

            Assert.IsTrue(conta.Valid);
        }
        #endregion
        #region ValidaçõesNomeConfirmacao
        [TestMethod]
        [DataTestMethod]
        //Cenário 01 - Nome 01     
        [DataRow("Pedro Vinicius")]
        //Cenário 02 - Nome 02       
        [DataRow("Pingao")]

        public void RetornaSucessoCasoNomeAlterado(string nome)
        {
            var conta = new Conta(nome, _valorTotal, _qtdParcelas, _dataPrimeiroPgto, _frequenciaPgto, _porcVariacaoMensal, _usuarioId);

            Assert.IsTrue(conta.Nome == nome);
        }
        #endregion

        #region ValidaçõesDataPrimeiroPgtoInválido
        [TestMethod]
        [DynamicData("_maiorDataNaoAceita")]
        [DataTestMethod]
        //Cenário 01 - DataPrimeiroPgto nula
        [DataRow(null)]        
        public void RetornaErroCasoDataPrimeiroPgtoInvalido(DateTime dataPrimeiroPgto)
        {
            var conta = new Conta(_nome, _valorTotal, _qtdParcelas, dataPrimeiroPgto, _frequenciaPgto, _porcVariacaoMensal, _usuarioId);            
            Assert.IsTrue(conta.Invalid);
        }
        #endregion
        #region ValidaçõesDataPrimeiroPgtoVálido
        [TestMethod]
        [DynamicData("_primeiroPgto1MesAFrente")]
        [DynamicData("_primeiroPgto2MesesATras")]
        public void RetornaSucessoCasoDataPrimeiroPgtoValido(DateTime dataPrimeiroPgto)
        {
            var conta = new Conta(_nome, _valorTotal, _qtdParcelas, dataPrimeiroPgto, _frequenciaPgto, _porcVariacaoMensal, _usuarioId);
            Assert.IsTrue(conta.Valid);
        }
        #endregion        
        #region ValidaçõesDataPrimeiroPgtoConfirmacao
        [TestMethod]
        [DynamicData("_primeiroPgto1MesAFrente")]
        [DynamicData("_primeiroPgto2MesesATras")]
        public void RetornaSucessoCasoDataPrimeiroPgtoAlterado(DateTime dataPrimeiroPgto)
        {
            var conta = new Conta(_nome, _valorTotal, _qtdParcelas, dataPrimeiroPgto, _frequenciaPgto, _porcVariacaoMensal, _usuarioId);

            Assert.IsTrue(conta.DataPrimeiroPgto == dataPrimeiroPgto);
        }
        #endregion

        #region ValidaçõesQtdParcelasInválidas    
        [TestMethod]
        [DataTestMethod]
        //Cenário 01 - Qtd Parcelas zeradas
        [DataRow(0)]
        //Cenário 02 - Qtd Parcelas negativas
        [DataRow(-20)]
        public void RetornaErroCasoQtdParcelasInvalidas(int qtdParcela)
        {
            var conta = new Conta(_nome, _valorTotal, qtdParcela, _dataPrimeiroPgto, _frequenciaPgto, _porcVariacaoMensal, _usuarioId);

            Assert.IsTrue(conta.Invalid);
        }
        #endregion
        #region ValidaçõesQtdParcelasVálidas    
        [TestMethod]
        [DataTestMethod]
        //Cenário 01 - Não parcelado
        [DataRow(1)]
        //Cenário 02 - Parcelado
        [DataRow(2)]
        public void RetornaSucessoCasoQtdParcelasValidas(int qtdParcela)
        {
            var conta = new Conta(_nome, _valorTotal, qtdParcela, _dataPrimeiroPgto, _frequenciaPgto, _porcVariacaoMensal, _usuarioId);

            Assert.IsTrue(conta.Valid);
        }
        #endregion
        #region ValidaçõesQtdParcelasConfirmação   
        [TestMethod]
        [DataTestMethod]
        //Cenário 01 - Não parcelado
        [DataRow(1)]
        //Cenário 02 - Parcelado
        [DataRow(2)]
        public void RetornaSucessoCasoQtdParcelasAlterado(int qtdParcela)
        {
            var conta = new Conta(_nome, _valorTotal, qtdParcela, _dataPrimeiroPgto, _frequenciaPgto, _porcVariacaoMensal, _usuarioId);           

            Assert.IsTrue(conta.QtdParcelas == qtdParcela);
        }
        #endregion

        #region ValidaçõesFrequenciaDiaPgtoInválido    
        [TestMethod]
        [DataTestMethod]
        //Cenário 01 - Frequencia de pagamentos zerados 
        [DataRow(0)]
        //Cenário 02 -Frequencia de pagamentos negativas
        [DataRow(-1)]
        public void RetornaErroCasoFrequenciaDiaPgtoInvalido(int frequenciaDiaPgto)
        {
            var conta = new Conta(_nome, _valorTotal, _qtdParcelas, _dataPrimeiroPgto, frequenciaDiaPgto, _porcVariacaoMensal, _usuarioId);

            Assert.IsTrue(conta.Invalid);
        }
        #endregion
        #region ValidaçõesFrequenciaDiaPgtoVálido
        [TestMethod]
        [DataTestMethod]
        //Cenário 01 - Semanal
        [DataRow(7)]
        //Cenário 02 - Quinzenal
        [DataRow(15)]
        //Cenário 02 - Mensal
        [DataRow(30)]
        public void RetornaSucessoCasoFrequenciaDiaPgtoValido(int frequenciaDiaPgto)
        {
            var conta = new Conta(_nome, _valorTotal, _qtdParcelas, _dataPrimeiroPgto, frequenciaDiaPgto, _porcVariacaoMensal, _usuarioId);

            Assert.IsTrue(conta.Valid);
        }
        #endregion
        #region ValidaçõesFrequenciaDiaPgtoConfirmação   
        [TestMethod]
        [DataTestMethod]
        //Cenário 01 - Não parcelado
        [DataRow(7)]
        //Cenário 02 - Parcelado
        [DataRow(30)]
        public void RetornaSucessoCasoFrequenciaDiaPgtoAlterado(int frequenciaDiaPgto)
        {
            var conta = new Conta(_nome, _valorTotal, _qtdParcelas, _dataPrimeiroPgto, frequenciaDiaPgto, _porcVariacaoMensal, _usuarioId);

            Assert.IsTrue(conta.FrequenciaDiaPgto == frequenciaDiaPgto);
        }
        #endregion

        #region ValidaçõesPorcVariacaoMensalInválidas    
        public static IEnumerable<object[]> percentualErrado
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                        1000,
                        5,
                        10,
                        new List<double> {
                            1000,
                            1000,
                            1000,
                            1000,
                            1000
                        }
                    }
                };
            }
        }

        [TestMethod]
        //mesmo valor
        [DynamicData("percentualErrado")]
        public void RetornaErroCasosPorcVariacaoMensalGerandoIncorreto(int valorTotal, int qtdParcelas, int porcVariacaoMensal, List<double> valoresParcelasCorretos)
        {
            var conta = new Conta(_nome, valorTotal, qtdParcelas, _dataPrimeiroPgto, _frequenciaPgto, porcVariacaoMensal, _usuarioId);

            var variacaoGeradaIncorretamente = true;
            var indexParcela = 0;
            foreach (var parcela in conta.Parcelas)
            {
                if (parcela.Valor == valoresParcelasCorretos[indexParcela])
                    variacaoGeradaIncorretamente = false;

                indexParcela++;
            }

            Assert.IsTrue(variacaoGeradaIncorretamente);
        }
        #endregion
        #region ValidaçõessPorcVariacaoMensalVálidas    
        [TestMethod]
        [DataTestMethod]
        //Cenário 01 - PorcVariacaoMensal negativa
        [DataRow(-10)]
        //Cenário 02 - PorcVariacaoMensal Zerada
        [DataRow(0)]
        //Cenário 03 - PorcVariacaoMensal Positiva
        [DataRow(10)]
        public void RetornaSucessoCasosPorcVariacaoMensalValidas(int porcVariacaoMensal)
        {
            var conta = new Conta(_nome, _valorTotal,_qtdParcelas, _dataPrimeiroPgto, _frequenciaPgto, porcVariacaoMensal, _usuarioId);

            Assert.IsTrue(conta.Valid);
        }
        #endregion
        #region ValidaçõessPorcVariacaoMensalConfirmação   
        [TestMethod]
        [DataTestMethod]
        //Cenário 01 - Não parcelado
        [DataRow(1)]
        //Cenário 02 - Parcelado
        [DataRow(2)]
        public void RetornaSucessoCasosPorcVariacaoMensalAlterado(int porcVariacaoMensal)
        {
            var conta = new Conta(_nome, _valorTotal, _qtdParcelas, _dataPrimeiroPgto, _frequenciaPgto, porcVariacaoMensal, _usuarioId);

            Assert.IsTrue(conta.PorcVariacaoMensal == porcVariacaoMensal);
        }

        public static IEnumerable<object[]> percentualCorreto
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                        1000,
                        5,
                        10,                      
                        new List<double> {
                            200,
                            220,
                            242,
                            266.2,
                            292.82
                        }
                    }
                };
            }
        }

        [TestMethod]
        //frequencia semanal
        [DynamicData("percentualCorreto")]
        public void RetornaSucessoCasosPorcVariacaoMensalGerandoCorretamente(int valorTotal, int qtdParcelas, int porcVariacaoMensal, List<double> valoresParcelasCorretos)
        {
            var conta = new Conta(_nome, valorTotal, qtdParcelas, _dataPrimeiroPgto, _frequenciaPgto, porcVariacaoMensal, _usuarioId);

            var variacaoGeradaCorretamente = true;
            var indexParcela = 0;
            foreach (var parcela in conta.Parcelas)
            {
                if (parcela.Valor != valoresParcelasCorretos[indexParcela])
                    variacaoGeradaCorretamente = false;

                indexParcela ++;
            }

            Assert.IsTrue(variacaoGeradaCorretamente);
        }
        #endregion

        #region ValidaçõesGeraçãoParcelasInválidas
        [TestMethod]       
        [DynamicData("_primeiroPgto1MesAFrente")]
        [DynamicData("_primeiroPgto2MesesATras")]
        public void RetornaErroCasoDataPrimeiraParcelaDivergenteDasParcelas(DateTime dataPrimeiroPgto)
        {
            var conta = new Conta(_nome, _valorTotal, _qtdParcelas, dataPrimeiroPgto, _frequenciaPgto, _porcVariacaoMensal, _usuarioId);

            var parcela = new ParcelasConta().SelecionarParcela(1, (List<Parcela>)conta.Parcelas);

            Assert.IsTrue(parcela.DataParcela == dataPrimeiroPgto);
        }


        #endregion
        #region ValidaçõesGeraçãoParcelasVálidas



        #endregion
        #region ValidaçõesGeraçãoParcelasConfirmacao
        public static IEnumerable<object[]> semanal
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                        1000,
                        5,
                        7,
                        new DateTime(2018, 5, 20),
                        new List<DateTime>
                        {
                            new DateTime(2018, 5, 20),
                            new DateTime(2018,5, 27),
                            new DateTime(2018, 6, 3),
                            new DateTime(2018, 6, 10),
                            new DateTime(2018, 6, 17)
                        }
                    }
                };
            }
        }
        public static IEnumerable<object[]> quinzenal
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                        1000,
                        5,
                        15,
                        new DateTime(2018, 5, 20),
                        new List<DateTime>
                        {
                            new DateTime(2018, 5, 20),
                            new DateTime(2018, 6, 4),
                            new DateTime(2018, 6, 19),
                            new DateTime(2018, 7, 4),
                            new DateTime(2018, 7, 19)
                        }
                    }
                };
            }
        }
        public static IEnumerable<object[]> mensal
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                        1000,
                        5,
                        30,
                        new DateTime(2018, 5, 20),
                        new List<DateTime>
                        {
                            new DateTime(2018, 5, 20),
                            new DateTime(2018, 6, 20),
                            new DateTime(2018, 7, 20),
                            new DateTime(2018, 8, 20),
                            new DateTime(2018, 9, 20)
                        }
                    }
                };
            }
        }
        [TestMethod]
        //frequencia semanal
        [DynamicData("semanal")]
        //frequencia quinzenal
        [DynamicData("quinzenal")]
        //frequancia mensal
        [DynamicData("mensal")]
        public void RetornaSucessoCasoDataDasParcelasCorretas(double valorTotal, int qtdParcelas, int frequenciaPgto, DateTime dataPrimeiroPgto, List<DateTime> datasEsperadas)
        {
            var conta = new Conta(_nome, valorTotal, qtdParcelas, dataPrimeiroPgto, frequenciaPgto, _porcVariacaoMensal, _usuarioId);

            var dataCorreta = true;
            var indexParcela = 0;
            foreach (var parcela in conta.Parcelas)
            {
                if (parcela.DataParcela != datasEsperadas[indexParcela])
                    dataCorreta = false;

                indexParcela++;
            }                

            Assert.IsTrue(dataCorreta);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(1000, 2)]
        [DataRow(999, 2)]
        [DataRow(999, 3)]
        public void RetornaSucessoCasoSomaDasParcelasIgualTotalConta(double valorTotal, int qtdParcelas)
        {
            var conta = new Conta(_nome, valorTotal, qtdParcelas, _dataPrimeiroPgto, _frequenciaPgto, _porcVariacaoMensal, _usuarioId);

            var valorParcelas = 0.0;

            foreach (var parcela in conta.Parcelas)
                valorParcelas += parcela.Valor;

            Assert.IsTrue(valorParcelas == valorTotal);
        }
        #endregion

        //#region Pgto Conta Inválido
        //[TestMethod]
        //[DataTestMethod]
        ////Cenário 01 - Valor pago negativo
        //[DataRow(-1, 1)]
        ////Cenário 02 - Valor pago parcela maior que o da conta
        //[DataRow(150, 1)]
        ////Cenário 03 - Menor parcela acima da ultima existente
        //[DataRow(100, 3)]
        ////Cenário 04 - Parcela negavita
        //[DataRow(100, -1)]
        ////Cenário 05 - Parcela zerada
        //[DataRow(100, 0)]
        //public void RetornaErroCasoPagamentoContaInvalido(double valorPago, int parcela)
        //{
        //    var conta = new Conta(_nome, _valorTotal, _qtdParcelas, _dataPrimeiroPgto, _frequenciaPgto, _porcVariacaoMensal, _usuarioId);

        //    //conta.PagarConta(valorPago, parcela);          

        //    Assert.IsTrue(conta.Invalid);
        //}
        //#endregion
        //#region Pgto Conta Válido
        //[TestMethod]
        //[DataTestMethod]
        ////Cenário 01 - Parcela pagamento correto
        //[DataRow(100, 1)]
        ////Cenário 02 - Parcela pagamento valor diferente do valor da parcela
        //[DataRow(30, 1)]
        //public void RetornaErroCasoPagamentoContaValido(double valorPago, int parcela)
        //{
        //    var conta = new Conta(_nome, _valorTotal, _qtdParcelas, _dataPrimeiroPgto, _frequenciaPgto, _porcVariacaoMensal, _usuarioId);

        //    // conta.PagarConta(valorPago, parcela);

        //    Assert.IsTrue(conta.Valid);
        //}
        //#endregion
    }
}
