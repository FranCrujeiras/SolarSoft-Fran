using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarSoft_1._0.Migrations
{
    /// <inheritdoc />
    public partial class CamposArbolesYEmisiones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Arboles",
                table: "Terrenos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Emisiones",
                table: "Terrenos",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Arboles",
                table: "Terrenos");

            migrationBuilder.DropColumn(
                name: "Emisiones",
                table: "Terrenos");
        }
    }
}
