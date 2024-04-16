using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarSoft_1._0.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionEstructuraPaneles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModeloPanel",
                table: "Terrenos");

            migrationBuilder.DropColumn(
                name: "Potencia",
                table: "Terrenos");

            migrationBuilder.DropColumn(
                name: "Voltaje",
                table: "Terrenos");

            migrationBuilder.AddColumn<int>(
                name: "ModeloPanelId",
                table: "Terrenos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Terrenos_ModeloPanelId",
                table: "Terrenos",
                column: "ModeloPanelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Terrenos_Panel_ModeloPanelId",
                table: "Terrenos",
                column: "ModeloPanelId",
                principalTable: "Panel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Terrenos_Panel_ModeloPanelId",
                table: "Terrenos");

            migrationBuilder.DropIndex(
                name: "IX_Terrenos_ModeloPanelId",
                table: "Terrenos");

            migrationBuilder.DropColumn(
                name: "ModeloPanelId",
                table: "Terrenos");

            migrationBuilder.AddColumn<string>(
                name: "ModeloPanel",
                table: "Terrenos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Potencia",
                table: "Terrenos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Voltaje",
                table: "Terrenos",
                type: "float",
                nullable: true);
        }
    }
}
