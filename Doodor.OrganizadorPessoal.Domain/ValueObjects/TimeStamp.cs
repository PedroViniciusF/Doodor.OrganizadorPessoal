using Doodor.OrganizadorPessoal.Domain.ValueObjects;
using System;

namespace Doodor.OrganizadorPessoal.Domain.Financeiro.ValueObjects
{
    public class TimeStamp : ValueObject
    {
        public TimeStamp()
        {
            Date = DateTime.Now;
        }
        public DateTime Date { get; set; }
    }
}
