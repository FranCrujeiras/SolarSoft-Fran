using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarSoft_1._0.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionModeloPanel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "totalPaneles",
                table: "Paneles",
                newName: "TotalPaneles");

            migrationBuilder.RenameColumn(
                name: "separacion",
                table: "Paneles",
                newName: "Separacion");

            migrationBuilder.RenameColumn(
                name: "potenciaTotal",
                table: "Paneles",
                newName: "PotenciaTotal");

            migrationBuilder.RenameColumn(
                name: "VOLTAJE",
                table: "Paneles",
                newName: "Voltaje");

            migrationBuilder.RenameColumn(
                name: "POTENCIA",
                table: "Paneles",
                newName: "Potencia");

            migrationBuilder.RenameColumn(
                name: "LONGITUDPANEL",
                table: "Paneles",
                newName: "LongitudPanel");

            migrationBuilder.RenameColumn(
                name: "LONGITUD",
                table: "Paneles",
                newName: "Longitud");

            migrationBuilder.RenameColumn(
                name: "LATITUD",
                table: "Paneles",
                newName: "Latitud");

            migrationBuilder.RenameColumn(
                name: "LARGOTERRENO",
                table: "Paneles",
                newName: "LargoTerreno");

            migrationBuilder.RenameColumn(
                name: "ANGULOESTRUCTURA",
                table: "Paneles",
                newName: "AnguloEstructura");

            migrationBuilder.RenameColumn(
                name: "ANCHOTERRENO",
                table: "Paneles",
                newName: "AnchoTerreno");

            migrationBuilder.RenameColumn(
                name: "ANCHOPANEL",
                table: "Paneles",
                newName: "AnchoPanel");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Paneles",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "ModeloPanel",
                table: "Paneles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModeloPanel",
                table: "Paneles");

            migrationBuilder.RenameColumn(
                name: "Voltaje",
                table: "Paneles",
                newName: "VOLTAJE");

            migrationBuilder.RenameColumn(
                name: "TotalPaneles",
                table: "Paneles",
                newName: "totalPaneles");

            migrationBuilder.RenameColumn(
                name: "Separacion",
                table: "Paneles",
                newName: "separacion");

            migrationBuilder.RenameColumn(
                name: "PotenciaTotal",
                table: "Paneles",
                newName: "potenciaTotal");

            migrationBuilder.RenameColumn(
                name: "Potencia",
                table: "Paneles",
                newName: "POTENCIA");

            migrationBuilder.RenameColumn(
                name: "LongitudPanel",
                table: "Paneles",
                newName: "LONGITUDPANEL");

            migrationBuilder.RenameColumn(
                name: "Longitud",
                table: "Paneles",
                newName: "LONGITUD");

            migrationBuilder.RenameColumn(
                name: "Latitud",
                table: "Paneles",
                newName: "LATITUD");

            migrationBuilder.RenameColumn(
                name: "LargoTerreno",
                table: "Paneles",
                newName: "LARGOTERRENO");

            migrationBuilder.RenameColumn(
                name: "AnguloEstructura",
                table: "Paneles",
                newName: "ANGULOESTRUCTURA");

            migrationBuilder.RenameColumn(
                name: "AnchoTerreno",
                table: "Paneles",
                newName: "ANCHOTERRENO");

            migrationBuilder.RenameColumn(
                name: "AnchoPanel",
                table: "Paneles",
                newName: "ANCHOPANEL");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Paneles",
                newName: "ID");
        }
    }
}
