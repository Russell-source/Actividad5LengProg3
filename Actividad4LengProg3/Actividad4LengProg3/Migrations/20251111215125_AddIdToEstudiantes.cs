using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Actividad4LengProg3.Migrations
{
    /// <inheritdoc />
    public partial class AddIdToEstudiantes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Estudiantes",
                table: "Estudiantes");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Estudiantes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estudiantes",
                table: "Estudiantes",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Estudiantes",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Estudiantes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estudiantes",
                table: "Estudiantes",
                column: "NombreCompleto");
        }
    }
}
