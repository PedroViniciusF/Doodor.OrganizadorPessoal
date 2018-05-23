using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Doodor.OrganizadorPessoal.Repo.SqlServer.Migrations
{
    public partial class trescampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "diavencimento",
                table: "contas",
                newName: "procvariacaomensal");

            migrationBuilder.AddColumn<DateTime>(
                name: "dataprimeiropgto",
                table: "contas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "frequenciadiapgto",
                table: "contas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dataprimeiropgto",
                table: "contas");

            migrationBuilder.DropColumn(
                name: "frequenciadiapgto",
                table: "contas");

            migrationBuilder.RenameColumn(
                name: "procvariacaomensal",
                table: "contas",
                newName: "diavencimento");
        }
    }
}
