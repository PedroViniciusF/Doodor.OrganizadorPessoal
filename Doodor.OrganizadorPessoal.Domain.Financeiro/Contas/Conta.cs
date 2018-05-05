using Doodor.OrganizadorPessoal.Domain.Entities;
using Doodor.OrganizadorPessoal.Domain.Financeiro.ValueObjects;
using Flunt.Validations;
using System;
using System.Collections.Generic;

namespace Doodor.OrganizadorPessoal.Domain.Financeiro.Entities
{
    public class Conta : Entity
    {
        #region Constructos

        public Conta()
        {
            Parcelas = new List<Parcela>();
        }

        //custrutor para criar uma nova conta
        public Conta(string nome, double valorTotal, int qtdParcelas, int diaVencimento)
        {
            Parcelas = new List<Parcela>();
            var parcelado = qtdParcelas > 1;

            ValidateDefault(nome, valorTotal, qtdParcelas, parcelado, diaVencimento);                     
            
            if (Valid)
            {
                Nome = nome;
                ValorTotal = valorTotal;
                DiaVencimento = diaVencimento;
                DataProxPgto = CalcularDataProxPgto(DiaVencimento);
                Parcelado = parcelado;

                var parcelasVo = new ParcelasConta();

                Parcelas = parcelasVo.CalcularParcelas(Id, DiaVencimento, ValorTotal, qtdParcelas);

                AddNotifications(parcelasVo);
                if(Valid)
                    QtdParcelas = Parcelas.Count;                
            }
        }      

        private Conta(Guid id, string nome, double valorTotal, int qtdParcelas, int diaVencimento)
            :this(nome, valorTotal, qtdParcelas, diaVencimento)
        {
            Id = id;

            AddNotifications(new Contract()
               .Requires()
               .IsNotNull(id, "Conta.Id", "Id obrigatorio para atualizar a conta")
               );
        }

        #endregion
        #region Validates
        private void ValidateDefault(string nome, double valorTotal, int qtdParcelas, bool parcelado, int diaVencimento)
        {
            //notificações validão o que tem que ser.
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(nome, "Conta.Nome", "Nome não pode ser nulo nem em branco")
                .HasMaxLen(nome, 100, "Conta.Nome", "Tamanho máximo de 100 caracteres")
                .HasMinLen(nome, 4, "Conta.Nome", "Tamanho mínimo de 4 caracteres")
                .IsTrue(!string.IsNullOrWhiteSpace(nome), "Conta.Nome", "O Nome não pode ser preenchido só por espaços")
                .IsTrue(diaVencimento > 0 && diaVencimento <= 31, "Conta.DiaVencimento", "Dia vencimento ínválido")
                .IsGreaterThan(qtdParcelas, 0, "Conta.QtdParcelas", "Quantidade de parcelas deve ser maior que 0")                
                .IsTrue(parcelado && qtdParcelas >= 2 || !parcelado && qtdParcelas == 1, "Conta.QtdParcelas", "Para uma conta parcelada a qtd de parcelas deve ser maior que 1")
                );
        }
        #endregion

        public string Nome { get; private set; }
        public double ValorTotal { get; private set; }        
        public bool Excluido { get; private set; }        
        public DateTime DataCadastro { get; private set; }
        //Informacoes pagamento
        //ia fazer um VO mas o entity framework barrou
        public DateTime DataProxPgto { get; private set; }
        public DateTime DataUltPgto { get; private set; }
        public double ValorPago { get; private set; }
        public bool Parcelado { get; private set; }
        public bool Pago { get; private set; }

        public int QtdParcelas { get; set; }
        public int DiaVencimento { get; set; }
        
        public virtual ICollection<Parcela> Parcelas { get; set; }

        #region Regras de Negócio 
        private DateTime CalcularDataProxPgto(int diaVencimento)
        {
            var dataAtual = DateTime.Now;
            return new DateTime(dataAtual.Year, dataAtual.Month, diaVencimento);
        }

        //public void PagarConta(double valorPago, int numParcela)
        //{
        //    AddNotifications(new Contract()
        //       .Requires()
        //       .IsGreaterThan(valorPago, 0, "Conta.ValorPago", "O valor pago deve ser positivo")
        //       .IsGreaterThan(numParcela, 0, "Conta.Parcela", "A parcela deve ser maior que 0")
        //       .IsLowerOrEqualsThan(valorPago, ValorTotal, "Conta.ValorPago", "O valor pago deve ser menor que o valor total da conta")
        //       );

        //    if (Invalid)
        //        return;

        //    var parcelaVO = new ParcelasConta();
        //    var parcela = parcelaVO.SelecionarParcela(numParcela, Parcelas);

        //    if (parcela != null && parcela.Valid)
        //    {
        //        var valorPagoNovoPgto = AdicionarVlPgtoConta(valorPago, numParcela);

        //        _parcelas = parcelaVO.PagarParcela(parcela.Numero, _parcelas);

        //        if (valorPagoNovoPgto == ValorTotal)
        //            Pago = true;
        //    }
        //    else
        //    {
        //        AddNotifications(parcela, parcelaVO);
        //    }
        //}

        public double AdicionarVlPgtoConta(double valorPago, int parcela)
        {
            DataUltPgto = DateTime.Now;

            return ValorPago += valorPago;
        }

        public void ExcluirConta()
        {
            //TODO: validações de negócio para excluir Conta
            Excluido = true;
        }       
        #endregion

        #region Factory
        // classe aninhada serve para usar os construtores default e dar possibilidades
        // de instanciar a classe passando mais coisas
        public static class ContaFactory
        {
            public static Conta NovaContaCompleta(Guid id, string nome, double valorTotal, int qtdParcelas, int diaVencimento)
            { 
                var conta = new Conta(id, nome, valorTotal, qtdParcelas, diaVencimento);
                
                return conta;
            }
        }
        #endregion
    }
}
