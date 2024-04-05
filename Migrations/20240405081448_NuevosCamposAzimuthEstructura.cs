using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarSoft_1._0.Migrations
{
    /// <inheritdoc />
    public partial class NuevosCamposAzimuthEstructura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Azimuth",
                table: "Terrenos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "InstalacionEstructura",
                table: "Terrenos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Azimuth",
                table: "Terrenos");

            migrationBuilder.DropColumn(
                name: "InstalacionEstructura",
                table: "Terrenos");
        }
    }
}
