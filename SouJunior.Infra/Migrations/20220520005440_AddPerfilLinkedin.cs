using Microsoft.EntityFrameworkCore.Migrations;

namespace SouJunior.Infra.Migrations
{
    public partial class AddPerfilLinkedin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PerfilLinkedin",
                table: "Proposta",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerfilLinkedin",
                table: "Proposta");
        }
    }
}
