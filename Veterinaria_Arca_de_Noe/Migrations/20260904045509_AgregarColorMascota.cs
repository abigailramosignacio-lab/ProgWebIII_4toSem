using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veterinaria_Arca_de_Noe.Migrations
{
    /// <inheritdoc />
    public partial class AgregarColorMascota : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Mascotas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Mascotas");
        }
    }
}
