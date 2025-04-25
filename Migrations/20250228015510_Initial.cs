using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GerenciamentoOficios.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Setores",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setores", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    CPF = table.Column<string>(type: "text", nullable: false),
                    SenhaHash = table.Column<string>(type: "text", nullable: false),
                    Contato = table.Column<string>(type: "text", nullable: false),
                    SetorID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Usuarios_Setores_SetorID",
                        column: x => x.SetorID,
                        principalTable: "Setores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Oficios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Conteudo = table.Column<string>(type: "text", nullable: false),
                    CaminhoArquivo = table.Column<string>(type: "text", nullable: false),
                    DataEnvio = table.Column<DateTime>(type: "timestamp", nullable: false),
                    DataRecebimento = table.Column<DateTime>(type: "timestamp", nullable: true),
                    RemetenteID = table.Column<int>(type: "integer", nullable: false),
                    DestinatarioID = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oficios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Oficios_Usuarios_DestinatarioID",
                        column: x => x.DestinatarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Oficios_Usuarios_RemetenteID",
                        column: x => x.RemetenteID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Oficios_DestinatarioID",
                table: "Oficios",
                column: "DestinatarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Oficios_RemetenteID",
                table: "Oficios",
                column: "RemetenteID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_SetorID",
                table: "Usuarios",
                column: "SetorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Oficios");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Setores");
        }
    }
}
