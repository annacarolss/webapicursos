using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCursos.Migrations
{
    /// <inheritdoc />
    public partial class CodigoTurma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Codigo",
                table: "Turmas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Turmas");
        }
    }
}
