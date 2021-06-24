using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiEstudo.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Geral");

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "Geral",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: true),
                    DataHoraCriacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Foto = table.Column<byte[]>(type: "bytea", nullable: true),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Casa",
                schema: "Geral",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    DataHoraCriacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AdminId = table.Column<long>(type: "bigint", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Casa_Usuario_AdminId",
                        column: x => x.AdminId,
                        principalSchema: "Geral",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mensagem",
                schema: "Geral",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CasaId = table.Column<long>(type: "bigint", nullable: false),
                    Texto = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mensagem_Casa_CasaId",
                        column: x => x.CasaId,
                        principalSchema: "Geral",
                        principalTable: "Casa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario_Casa",
                schema: "Geral",
                columns: table => new
                {
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    CasaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario_Casa", x => new { x.UsuarioId, x.CasaId });
                    table.ForeignKey(
                        name: "FK_Usuario_Casa_Casa_CasaId",
                        column: x => x.CasaId,
                        principalSchema: "Geral",
                        principalTable: "Casa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Casa_AdminId",
                schema: "Geral",
                table: "Casa",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_CasaId",
                schema: "Geral",
                table: "Mensagem",
                column: "CasaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Casa_CasaId",
                schema: "Geral",
                table: "Usuario_Casa",
                column: "CasaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mensagem",
                schema: "Geral");

            migrationBuilder.DropTable(
                name: "Usuario_Casa",
                schema: "Geral");

            migrationBuilder.DropTable(
                name: "Casa",
                schema: "Geral");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "Geral");
        }
    }
}
