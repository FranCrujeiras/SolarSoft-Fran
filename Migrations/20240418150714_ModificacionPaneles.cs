using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarSoft_1._0.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionPaneles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Terrenos_Panel_ModeloPanelId",
                table: "Terrenos");

            migrationBuilder.DropIndex(
                name: "IX_Terrenos_ModeloPanelId",
                table: "Terrenos");

            migrationBuilder.RenameColumn(
                name: "ModeloPanelId",
                table: "Terrenos",
                newName: "ModeloPanel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModeloPanel",
                table: "Terrenos",
                newName: "ModeloPanelId");

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
    }
}
