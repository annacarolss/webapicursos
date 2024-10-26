using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCursos.Migrations
{
    /// <inheritdoc />
    public partial class AddRelacionamentoEstudanteTurma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstudanteTurma",
                columns: table => new
                {
                    EstudanteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TurmasId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudanteTurma", x => new { x.EstudanteId, x.TurmasId });
                    table.ForeignKey(
                        name: "FK_EstudanteTurma_Estudantes_EstudanteId",
                        column: x => x.EstudanteId,
                        principalTable: "Estudantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstudanteTurma_Turmas_TurmasId",
                        column: x => x.TurmasId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstudanteTurma_TurmasId",
                table: "EstudanteTurma",
                column: "TurmasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstudanteTurma");
        }
    }
}
