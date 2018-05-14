using Doodor.OrganizadorPessoal.Domain.Authentication;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Entities;
using Doodor.OrganizadorPessoal.Repo.SqlServer.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Doodor.OrganizadorPessoal.Repo.SqlServer.Mappings
{
    public class UsuarioMapping : EntityTypeConfiguration<Usuario>
    {
        public override void Map(EntityTypeBuilder<Usuario> modelBuilder)
        {
            modelBuilder
                .Property(x => x.Id)
                .ToString().ToLower();

            modelBuilder
               .Property(x => x.Nome)
               .HasColumnName("nome")
               .HasColumnType("varchar(100)");
            modelBuilder
               .Property(x => x.Email)
               .HasColumnName("email")
               .HasColumnType("varchar(40)");

            modelBuilder
                .Property(x => x.Cpf)
                .HasColumnName("cpf")
                .HasColumnType("varchar(11)");
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
                .ToTable("usuarios");
        }
    }
}
