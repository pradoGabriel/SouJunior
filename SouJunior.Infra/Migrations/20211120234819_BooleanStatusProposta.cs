using Microsoft.EntityFrameworkCore.Migrations;

namespace SouJunior.Infra.Migrations
{
    public partial class BooleanStatusProposta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empreendedor_RamoAtuacao_RamoAtuacaoId",
                table: "Empreendedor");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpresaJr_RamoAtuacao_RamoAtuacaoId",
                table: "EmpresaJr");

            migrationBuilder.AddColumn<bool>(
                name: "IsAceita",
                table: "Proposta",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RamoAtuacaoId",
                table: "EmpresaJr",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RamoAtuacaoId",
                table: "Empreendedor",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Empreendedor_RamoAtuacao_RamoAtuacaoId",
                table: "Empreendedor",
                column: "RamoAtuacaoId",
                principalTable: "RamoAtuacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpresaJr_RamoAtuacao_RamoAtuacaoId",
                table: "EmpresaJr",
                column: "RamoAtuacaoId",
                principalTable: "RamoAtuacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empreendedor_RamoAtuacao_RamoAtuacaoId",
                table: "Empreendedor");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpresaJr_RamoAtuacao_RamoAtuacaoId",
                table: "EmpresaJr");

            migrationBuilder.DropColumn(
                name: "IsAceita",
                table: "Proposta");

            migrationBuilder.AlterColumn<int>(
                name: "RamoAtuacaoId",
                table: "EmpresaJr",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "RamoAtuacaoId",
                table: "Empreendedor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Empreendedor_RamoAtuacao_RamoAtuacaoId",
                table: "Empreendedor",
                column: "RamoAtuacaoId",
                principalTable: "RamoAtuacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpresaJr_RamoAtuacao_RamoAtuacaoId",
                table: "EmpresaJr",
                column: "RamoAtuacaoId",
                principalTable: "RamoAtuacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
