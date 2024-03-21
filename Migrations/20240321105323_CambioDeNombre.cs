using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarSoft_1._0.Migrations
{
    /// <inheritdoc />
    public partial class CambioDeNombre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paneles");

            migrationBuilder.CreateTable(
                name: "Terrenos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModeloPanel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LongitudPanel = table.Column<double>(type: "float", nullable: false),
                    AnchoPanel = table.Column<double>(type: "float", nullable: false),
                    Potencia = table.Column<int>(type: "int", nullable: false),
                    Voltaje = table.Column<double>(type: "float", nullable: false),
                    Latitud = table.Column<double>(type: "float", nullable: false),
                    Longitud = table.Column<double>(type: "float", nullable: false),
                    LargoTerreno = table.Column<double>(type: "float", nullable: false),
                    AnchoTerreno = table.Column<double>(type: "float", nullable: false),
                    AnguloEstructura = table.Column<int>(type: "int", nullable: false),
                    Separacion = table.Column<double>(type: "float", nullable: true),
                    PotenciaTotal = table.Column<int>(type: "int", nullable: true),
                    TotalPaneles = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terrenos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Terrenos");

            migrationBuilder.CreateTable(
                name: "Paneles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnchoPanel = table.Column<double>(type: "float", nullable: false),
                    AnchoTerreno = table.Column<double>(type: "float", nullable: false),
                    AnguloEstructura = table.Column<int>(type: "int", nullable: false),
                    LargoTerreno = table.Column<double>(type: "float", nullable: false),
                    Latitud = table.Column<double>(type: "float", nullable: false),
                    Longitud = table.Column<double>(type: "float", nullable: false),
                    LongitudPanel = table.Column<double>(type: "float", nullable: false),
                    ModeloPanel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Potencia = table.Column<int>(type: "int", nullable: false),
                    PotenciaTotal = table.Column<int>(type: "int", nullable: true),
                    Separacion = table.Column<double>(type: "float", nullable: true),
                    TotalPaneles = table.Column<int>(type: "int", nullable: true),
                    Voltaje = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paneles", x => x.Id);
                });
        }
    }
}
