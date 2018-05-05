﻿using Doodor.OrganizadorPessoal.Domain.Commands;
using System;


namespace Doodor.OrganizadorPessoal.Domain.Financeiro.Commands
{
    public class CriarContaCommand : Command
    {
        public CriarContaCommand(Guid aggregateId, string nome, double valorTotal, int qtdParcelas, int diaVencimento)
        {
            Nome = nome;
            ValorTotal = valorTotal;            
            QtdParcelas = qtdParcelas;                        
            DiaVencimento = diaVencimento;

            AggregateId = aggregateId;
        }
        public string Nome { get; private set; }
        public double ValorTotal { get; private set; }        
        public int QtdParcelas { get; private set; }               
        public int DiaVencimento { get; private set; }
    }
}
