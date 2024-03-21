using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarSoft_1._0.Migrations
{
    /// <inheritdoc />
    public partial class EliminacionCamposExcedentes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnchoPanel",
                table: "Terrenos");

            migrationBuilder.DropColumn(
                name: "LongitudPanel",
                table: "Terrenos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AnchoPanel",
                table: "Terrenos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LongitudPanel",
                table: "Terrenos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
