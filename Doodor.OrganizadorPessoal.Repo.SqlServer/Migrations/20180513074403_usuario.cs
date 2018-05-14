using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Doodor.OrganizadorPessoal.Repo.SqlServer.Migrations
{
    public partial class usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    cpf = table.Column<string>(type: "varchar(11)", nullable: true),
                    email = table.Column<string>(type: "varchar(40)", nullable: true),
                    nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    ultimaalteracao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "contas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    datacadastro = table.Column<DateTime>(nullable: false),
                    dataproxpgto = table.Column<DateTime>(nullable: false),
                    dataultpgto = table.Column<DateTime>(nullable: false),
                    diavencimento = table.Column<int>(nullable: false),
                    excluido = table.Column<bool>(nullable: false),
                    nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    pago = table.Column<bool>(nullable: false),
                    parcelado = table.Column<bool>(nullable: false),
                    qtdparcelas = table.Column<int>(nullable: false),
                    ultimaalteracao = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    valorpago = table.Column<double>(nullable: false),
                    valortotal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contas_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "parcelas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    contaid = table.Column<Guid>(nullable: false),
                    dataparcela = table.Column<DateTime>(nullable: false),
                    datapgto = table.Column<DateTime>(nullable: false),
                    numero = table.Column<int>(nullable: false),
                    pago = table.Column<bool>(nullable: false),
                    ultimaalteracao = table.Column<DateTime>(nullable: false),
                    valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parcelas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_parcelas_contas_contaid",
                        column: x => x.contaid,
                        principalTable: "contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contas_UsuarioId",
                table: "contas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_parcelas_contaid",
                table: "parcelas",
                column: "contaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "parcelas");

            migrationBuilder.DropTable(
                name: "contas");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
