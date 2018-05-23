using Doodor.OrganizadorPessoal.Domain.Financeiro.Entities;
using Doodor.OrganizadorPessoal.Repo.SqlServer.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doodor.OrganizadorPessoal.Repo.SqlServer.Mappings
{
    public class ContaMapping : EntityTypeConfiguration<Conta>
    {
        public override void Map(EntityTypeBuilder<Conta> modelBuilder)
        {
            modelBuilder
                .Property(x => x.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(100)");
            modelBuilder
                .Property(x => x.ValorTotal)
                .HasColumnName("valortotal");
            modelBuilder
                .Property(x => x.Pago)
                .HasColumnName("pago");
            modelBuilder
                .Property(x => x.Excluido)
                .HasColumnName("excluido");
            modelBuilder
                .Property(x => x.DataPrimeiroPgto)
                .HasColumnName("dataprimeiropgto");
            modelBuilder
                .Property(x => x.FrequenciaDiaPgto)
                .HasColumnName("frequenciadiapgto");
            modelBuilder
                .Property(x => x.PorcVariacaoMensal)
                .HasColumnName("porcvariacaomensal");
            modelBuilder
                .Property(x => x.DataProxPgto)
                .HasColumnName("dataproxpgto");
            modelBuilder
                .Property(x => x.DataUltPgto)
                .HasColumnName("dataultpgto");
            modelBuilder
                .Property(x => x.Parcelado)
                .HasColumnName("parcelado");
            modelBuilder
                .Property(x => x.ValorPago)
                .HasColumnName("valorpago");
            modelBuilder
                .Property(x => x.DataCadastro)
                .HasColumnName("datacadastro");
            modelBuilder
                .Property(x => x.UltimaAlteracao)
                .HasColumnName("ultimaalteracao");
            modelBuilder
                .Property(x => x.QtdParcelas)
                .HasColumnName("qtdparcelas");

            modelBuilder
                .Ignore(x => x.Notifications);
            modelBuilder
                .Ignore(x => x.Invalid);
            modelBuilder
                .Ignore(x => x.Valid);

            modelBuilder
                .HasMany(x => x.Parcelas)
                .WithOne(x => x.Conta);

            modelBuilder
                .HasOne(x => x.Usuario)
                .WithMany(x=>x.Contas)
                .HasForeignKey(x => x.UsuarioId);

            modelBuilder
                .ToTable("contas");
        }
    }
}
