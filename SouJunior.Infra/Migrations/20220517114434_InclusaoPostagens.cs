using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SouJunior.Infra.Migrations
{
    public partial class InclusaoPostagens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EstudanteId",
                table: "Proposta",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Postagem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PropostaId = table.Column<Guid>(nullable: false),
                    Mensagem = table.Column<string>(nullable: true),
                    DataHora = table.Column<DateTime>(nullable: false),
                    NomeUsuario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postagem", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Postagem");

            migrationBuilder.DropColumn(
                name: "EstudanteId",
                table: "Proposta");
        }
    }
}
