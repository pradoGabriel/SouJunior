using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SouJunior.Infra.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nota = table.Column<int>(nullable: false),
                    Comentario = table.Column<string>(nullable: true),
                    PropostaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Candidato",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsSelecionado = table.Column<bool>(nullable: false),
                    LinkedinProfile = table.Column<string>(nullable: true),
                    InformacoesAdicionais = table.Column<string>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Logradouro = table.Column<string>(nullable: true),
                    Cep = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estudante",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Cpf = table.Column<string>(nullable: true),
                    Instituicao = table.Column<string>(nullable: true),
                    Curso = table.Column<string>(nullable: true),
                    Periodo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proposta",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    EmpresaJrId = table.Column<Guid>(nullable: false),
                    EmpreendedorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RamoAtuacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RamoAtuacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empreendedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Cnpj = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    RazaoSocial = table.Column<string>(nullable: true),
                    NomeFantasia = table.Column<string>(nullable: true),
                    RamoAtuacaoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empreendedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empreendedor_RamoAtuacao_RamoAtuacaoId",
                        column: x => x.RamoAtuacaoId,
                        principalTable: "RamoAtuacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaJr",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Cnpj = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    RazaoSocial = table.Column<string>(nullable: true),
                    NomeFantasia = table.Column<string>(nullable: true),
                    RamoAtuacaoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaJr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpresaJr_RamoAtuacao_RamoAtuacaoId",
                        column: x => x.RamoAtuacaoId,
                        principalTable: "RamoAtuacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    ImagemPerfil = table.Column<string>(nullable: true),
                    EnderecoId = table.Column<Guid>(nullable: true),
                    EmpresaJrId = table.Column<Guid>(nullable: true),
                    EmpreendedorId = table.Column<Guid>(nullable: true),
                    EstudanteId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Empreendedor_EmpreendedorId",
                        column: x => x.EmpreendedorId,
                        principalTable: "Empreendedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_EmpresaJr_EmpresaJrId",
                        column: x => x.EmpresaJrId,
                        principalTable: "EmpresaJr",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_Estudante_EstudanteId",
                        column: x => x.EstudanteId,
                        principalTable: "Estudante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empreendedor_RamoAtuacaoId",
                table: "Empreendedor",
                column: "RamoAtuacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaJr_RamoAtuacaoId",
                table: "EmpresaJr",
                column: "RamoAtuacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EmpreendedorId",
                table: "Usuario",
                column: "EmpreendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EmpresaJrId",
                table: "Usuario",
                column: "EmpresaJrId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EnderecoId",
                table: "Usuario",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EstudanteId",
                table: "Usuario",
                column: "EstudanteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Candidato");

            migrationBuilder.DropTable(
                name: "Proposta");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Empreendedor");

            migrationBuilder.DropTable(
                name: "EmpresaJr");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Estudante");

            migrationBuilder.DropTable(
                name: "RamoAtuacao");
        }
    }
}
