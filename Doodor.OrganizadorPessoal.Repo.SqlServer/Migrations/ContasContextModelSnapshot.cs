﻿// <auto-generated />
using Doodor.OrganizadorPessoal.Repo.SqlServer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Doodor.OrganizadorPessoal.Repo.SqlServer.Migrations
{
    [DbContext(typeof(ContasContext))]
    partial class ContasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Doodor.OrganizadorPessoal.Domain.Authentication.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cpf")
                        .HasColumnName("cpf")
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Nome")
                        .HasColumnName("nome")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("UltimaAlteracao")
                        .HasColumnName("ultimaalteracao");

                    b.HasKey("Id");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("Doodor.OrganizadorPessoal.Domain.Financeiro.Entities.Conta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("datacadastro");

                    b.Property<DateTime>("DataProxPgto")
                        .HasColumnName("dataproxpgto");

                    b.Property<DateTime>("DataUltPgto")
                        .HasColumnName("dataultpgto");

                    b.Property<int>("DiaVencimento")
                        .HasColumnName("diavencimento");

                    b.Property<bool>("Excluido")
                        .HasColumnName("excluido");

                    b.Property<string>("Nome")
                        .HasColumnName("nome")
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("Pago")
                        .HasColumnName("pago");

                    b.Property<bool>("Parcelado")
                        .HasColumnName("parcelado");

                    b.Property<int>("QtdParcelas")
                        .HasColumnName("qtdparcelas");

                    b.Property<DateTime>("UltimaAlteracao")
                        .HasColumnName("ultimaalteracao");

                    b.Property<Guid>("UsuarioId");

                    b.Property<double>("ValorPago")
                        .HasColumnName("valorpago");

                    b.Property<double>("ValorTotal")
                        .HasColumnName("valortotal");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("contas");
                });

            modelBuilder.Entity("Doodor.OrganizadorPessoal.Domain.Financeiro.Entities.Parcela", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ContaId")
                        .HasColumnName("contaid");

                    b.Property<DateTime>("DataParcela")
                        .HasColumnName("dataparcela");

                    b.Property<DateTime>("DataPgto")
                        .HasColumnName("datapgto");

                    b.Property<int>("Numero")
                        .HasColumnName("numero");

                    b.Property<bool>("Pago")
                        .HasColumnName("pago");

                    b.Property<DateTime>("UltimaAlteracao")
                        .HasColumnName("ultimaalteracao");

                    b.Property<double>("Valor")
                        .HasColumnName("valor");

                    b.HasKey("Id");

                    b.HasIndex("ContaId");

                    b.ToTable("parcelas");
                });

            modelBuilder.Entity("Doodor.OrganizadorPessoal.Domain.Financeiro.Entities.Conta", b =>
                {
                    b.HasOne("Doodor.OrganizadorPessoal.Domain.Authentication.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Doodor.OrganizadorPessoal.Domain.Financeiro.Entities.Parcela", b =>
                {
                    b.HasOne("Doodor.OrganizadorPessoal.Domain.Financeiro.Entities.Conta", "Conta")
                        .WithMany("Parcelas")
                        .HasForeignKey("ContaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
