using Doodor.OrganizadorPessoal.Domain.Entities;
using Doodor.OrganizadorPessoal.Domain.Financeiro.ValueObjects;
using Flunt.Validations;
using System;

namespace Doodor.OrganizadorPessoal.Domain.Financeiro.Entities
{
    public class Parcela : Entity
    {
        public Parcela(Guid contaId, int numero, double valor, DateTime dataParcela)
        {
            ContaId = contaId;
            Numero = numero;
            Valor = valor;
            DataParcela = dataParcela;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(ContaId, "Parcela.ContaId", "Id de conta inválido")
                .IsTrue(Numero >= 0, "Parcela.Numero", "Número da parcela inválido")
                .IsTrue(Valor >= 0, "Parcela.Valor", "Valor da parcela inválido")
                .IsGreaterThan(DataParcela, new DateTime(1000, 1, 1), "Parcela.DataParcela", "Data da parcela deve ser maior que 01/01/1000")
                );
        }

        public Parcela()
        {

        }

        public Guid ContaId { get; private set; }

        public int Numero { get; private set; }
        public double Valor { get; private set; }
        public bool Pago { get; private set; }
        public DateTime DataParcela { get; private set; }
        public DateTime DataPgto { get; set; }       

        public virtual Conta Conta { get; private set; }

        public void PagarParcela()
        {
            Pago = true;
            DataPgto = DateTime.Now;
        }
    }
}
