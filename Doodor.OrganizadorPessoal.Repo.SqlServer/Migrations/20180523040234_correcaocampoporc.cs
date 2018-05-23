using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Doodor.OrganizadorPessoal.Repo.SqlServer.Migrations
{
    public partial class correcaocampoporc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "procvariacaomensal",
                table: "contas",
                newName: "porcvariacaomensal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "porcvariacaomensal",
                table: "contas",
                newName: "procvariacaomensal");
        }
    }
}
