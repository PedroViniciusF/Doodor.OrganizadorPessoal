using Doodor.OrganizadorPessoal.Domain.Entities;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Entities;
using Doodor.OrganizadorPessoal.Domain.ValueObjects;
using Flunt.Validations;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Doodor.OrganizadorPessoal.Domain.Financeiro.ValueObjects
{
    public class ParcelasConta : ValueObject
    {        
        public List<Parcela> CalcularParcelas(Guid contaId, DateTime dataPrimeiroPgto, double valorTotal, int qtdParcelas, int frequenciaDiaPgto, int porcVariacaoMensal)
        {
            var parcelas = new List<Parcela>();
            var valorParcela = valorTotal / qtdParcelas;

            for (int numParcela = 1; numParcela <= qtdParcelas; numParcela++)
            {
                var vencimentoParcela = new DateTime();
                if (numParcela == 1)
                {
                    vencimentoParcela = dataPrimeiroPgto;
                }
                else
                {
                    var dataPgtoUltimaParcela = GetDataParcelaUltimaParcela(numParcela, parcelas);
                    vencimentoParcela = new VencimentoParcela(dataPrimeiroPgto, numParcela, frequenciaDiaPgto, dataPgtoUltimaParcela)
                        .DataVencimento;                
                }
            

                var parcela = new Parcela(contaId, numParcela, valorParcela, vencimentoParcela);

                if (parcela.Invalid)
                    AddNotifications(parcela);

                if (Invalid)
                    return null;

                parcelas.Add(parcela);

                if (porcVariacaoMensal != 0)
                {                    
                    valorParcela = (((double)porcVariacaoMensal / 100) * valorParcela) + valorParcela;
                }
            }


            return parcelas;
        }

        public List<Parcela> PagarParcela(int numParcela, List<Parcela> parcelas)
        {           
            foreach (var parcela in parcelas)
            {
                if (parcela.Numero.Equals(numParcela))
                {
                    parcela.PagarParcela();
                }
            }

            return parcelas;
        }

        public Parcela SelecionarParcela(int numParcela, List<Parcela> parcelas)
        {
            var parcela = parcelas.Find(x => x.Numero == numParcela);

            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(parcela, "Parcela.Numero", "Parcela não existe na conta")           
            );

            if (Valid)
                return parcela;

            return null;
        }

        private DateTime GetDataParcelaUltimaParcela(int parcelaAtual , List<Parcela> parcelas)
        {
            var numParcelaAnterior = parcelaAtual - 1;
            var parcela = SelecionarParcela(numParcelaAnterior, parcelas);

            return parcela.DataParcela;
        }
    }
}
