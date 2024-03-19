using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarSoft_1._0.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "potenciaTotal",
                table: "Paneles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "separacion",
                table: "Paneles",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "totalPaneles",
                table: "Paneles",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "potenciaTotal",
                table: "Paneles");

            migrationBuilder.DropColumn(
                name: "separacion",
                table: "Paneles");

            migrationBuilder.DropColumn(
                name: "totalPaneles",
                table: "Paneles");
        }
    }
}
