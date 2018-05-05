using System;
using System.Collections.Generic;

namespace Doodor.OrganizadorPessoal.Domain.Financeiro.ValueObjects
{
    public class VencimentoParcela
    {
        public VencimentoParcela(int diaVencimento, int parcela)
        {
            DiaVencimento = diaVencimento;
            Parcela = parcela;
            CalcularDataVencimento();
        }

        public VencimentoParcela()
        {

        }

        public int DiaVencimento { get; private set; }
        public int Parcela { get; set; }
        public DateTime DataVencimento { get; private set; }

        private void CalcularDataVencimento()
        {
            var dataAtual = DateTime.Now;
            int mesVencimento = dataAtual.Month + Parcela;
            int anoVencimento = dataAtual.Year;                       

            var mesAnoValidos = VerificaMesVencimentoValidoERetornaMesEAnoValido(mesVencimento, anoVencimento);

            mesVencimento = mesAnoValidos[0];
            anoVencimento = mesAnoValidos[1];

            DiaVencimento = VerificaDiaVencimentoValidoERetornaMenorDataValida(DiaVencimento, mesVencimento, anoVencimento);

            DataVencimento = new DateTime(anoVencimento, mesVencimento, DiaVencimento);
        }
        private IList<int> VerificaMesVencimentoValidoERetornaMesEAnoValido(int mesVencimento, int anoVencimento)
        {            
            var MesValido = mesVencimento;
            var AnoValido = anoVencimento;

            if (MesValido > 12)
            {
                MesValido = MesValido - 12;
                AnoValido++;
            }
            
            return new List<int>{ MesValido, AnoValido};            
        }

        private int VerificaDiaVencimentoValidoERetornaMenorDataValida(int diaVencimento, int mesVencimento, int anoVencimento)
        {
            var maiorDiaDoMes = DateTime.DaysInMonth(anoVencimento, mesVencimento);

            if (diaVencimento > maiorDiaDoMes)
                return maiorDiaDoMes;

            return diaVencimento;
        }
    }
}
