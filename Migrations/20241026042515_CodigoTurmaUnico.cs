﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCursos.Migrations
{
    /// <inheritdoc />
    public partial class CodigoTurmaUnico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Turmas_Codigo",
                table: "Turmas",
                column: "Codigo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Turmas_Codigo",
                table: "Turmas");
        }
    }
}
