using Doodor.OrganizadorPessoal.Domain.Financeiro.Entities;
using Doodor.OrganizadorPessoal.Domain.Financeiro.ValueObjects;
using Doodor.OrganizadorPessoal.Repo.SqlServer.Extensions;
using Doodor.OrganizadorPessoal.Repo.SqlServer.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Doodor.OrganizadorPessoal.Repo.SqlServer.Context
{
    public class ContasContext : DbContext
    {
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Parcela> Parcelas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new ContaMapping());
            modelBuilder.AddConfiguration(new ParcelaMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));                  
        }
    }
}
