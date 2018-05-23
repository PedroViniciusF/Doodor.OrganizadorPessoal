using System;
using System.Collections.Generic;

namespace Doodor.OrganizadorPessoal.Domain.Financeiro.ValueObjects
{
    public class VencimentoParcela
    {
        public VencimentoParcela(DateTime dataPrimeiroPgto, int parcela, int frequenciaDiaPgto, DateTime dataPgtoUltimaParcela)
        {
            DataPrimeiroPgto = dataPrimeiroPgto;
            Parcela = parcela;
            FrequenciaDiaPgto = frequenciaDiaPgto;
            DataPgtoUltimaParcela = dataPgtoUltimaParcela;
            CalcularDataVencimento();
        }

        public VencimentoParcela()
        {

        }

        public DateTime DataPrimeiroPgto { get; private set; }
        public int Parcela { get; private set; }
        public int FrequenciaDiaPgto { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public DateTime DataPgtoUltimaParcela { get; private set; }

        private void CalcularDataVencimento()
        {
            if (FrequenciaDiaPgto >= 29)
                CalcularDataVencimentoMensal();
            else
                CalcularDataVencimentoMenorMensal();
        }
        private void CalcularDataVencimentoMensal()
        {
            int diaVencimento = DataPrimeiroPgto.Day;
            int mesVencimento = DataPrimeiroPgto.Month + (Parcela - 1);
            int anoVencimento = DataPrimeiroPgto.Year;

            var mesAnoValidos = VerificaMesVencimentoValidoERetornaMesEAnoValido(mesVencimento, anoVencimento);

            var mesVencimentoValido = mesAnoValidos[0];
            var anoVencimentoValido = mesAnoValidos[1];

            var diaVencimentoValido = VerificaDiaVencimentoValidoERetornaMenorDataValida(diaVencimento, mesVencimentoValido, anoVencimentoValido);

            DataVencimento = new DateTime(anoVencimentoValido, mesVencimentoValido, diaVencimentoValido);
        }
        private void CalcularDataVencimentoMenorMensal()
        {           
            int mesPgtoUltimaParcela = DataPgtoUltimaParcela.Month;
            int anoPgtOUltimaParcel = DataPgtoUltimaParcela.Year;

            int diaVencimento = DataPgtoUltimaParcela.Day + FrequenciaDiaPgto;

            int mesVencimento = 0;

            if (diaVencimento > DateTime.DaysInMonth(DataPgtoUltimaParcela.Year, DataPgtoUltimaParcela.Month))
            {
                mesVencimento = DataPgtoUltimaParcela.Month + 1;
            }
            else
            {
                mesVencimento = DataPgtoUltimaParcela.Month;
            }
            int anoVencimento = DataPgtoUltimaParcela.Year;

            var mesAnoValidos = VerificaMesVencimentoValidoERetornaMesEAnoValido(mesVencimento, anoVencimento);

            var mesVencimentoValido = mesAnoValidos[0];
            var anoVencimentoValido = mesAnoValidos[1];

            var diaVencimentoValido = VerificaDiaVencimentoValidoERetornaDataSomadaValida(diaVencimento, mesPgtoUltimaParcela, anoPgtOUltimaParcel);
            DataVencimento = new DateTime(anoVencimentoValido, mesVencimentoValido, diaVencimentoValido);
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
        private int VerificaDiaVencimentoValidoERetornaDataSomadaValida(int diaVencimento, int mesVencimentoUltParcela, int anoVencimentoUltParcela)
        {
            var maiorDiaDoMesUltParcela = DateTime.DaysInMonth(anoVencimentoUltParcela, mesVencimentoUltParcela);

            if (diaVencimento > maiorDiaDoMesUltParcela)
                return diaVencimento - maiorDiaDoMesUltParcela;

            return diaVencimento;
        }
    }
}
