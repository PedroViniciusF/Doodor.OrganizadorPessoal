using Doodor.OrganizadorPessoal.Domain.Financeiro.Entities;
using Doodor.OrganizadorPessoal.Repo.SqlServer.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doodor.OrganizadorPessoal.Repo.SqlServer.Mappings
{
    public class ParcelaMapping : EntityTypeConfiguration<Parcela>
    {
        public override void Map(EntityTypeBuilder<Parcela> modelBuilder)
        {
            modelBuilder
                .Property(x => x.Numero)
                .HasColumnName("numero");
            modelBuilder
              .Property(x => x.Valor)
              .HasColumnName("valor");
            modelBuilder
              .Property(x => x.Pago)
              .HasColumnName("pago");
            modelBuilder
              .Property(x => x.DataParcela)
              .HasColumnName("dataparcela");
            modelBuilder
              .Property(x => x.DataPgto)
              .HasColumnName("datapgto");
            modelBuilder
              .Property(x => x.ContaId)
              .HasColumnName("contaid");
            modelBuilder
              .Property(x => x.UltimaAlteracao)
              .HasColumnName("ultimaalteracao");

            modelBuilder
               .Ignore(x => x.Notifications);
            modelBuilder
                .Ignore(x => x.Invalid);
            modelBuilder
                .Ignore(x => x.Valid);

            modelBuilder
                    .HasOne(x => x.Conta)
                    .WithMany(x => x.Parcelas)
                    .HasForeignKey(x=>x.ContaId);                    

            modelBuilder
                .ToTable("parcelas");
        }
    }
}
