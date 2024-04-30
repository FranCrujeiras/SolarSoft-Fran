using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarSoft_1._0.Migrations
{
    /// <inheritdoc />
    public partial class BateriasEInversores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bateria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModeloBateria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacidad = table.Column<double>(type: "float", nullable: false),
                    PotenciaSalida = table.Column<double>(type: "float", nullable: false),
                    Modulos = table.Column<int>(type: "int", nullable: false),
                    VoltajeNominal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bateria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inversor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModeloInversor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EficienciaEuropea = table.Column<double>(type: "float", nullable: false),
                    PotenciaEntrada = table.Column<double>(type: "float", nullable: false),
                    VoltajeMinimoMPPT = table.Column<int>(type: "int", nullable: false),
                    VoltajeMaximoMPPT = table.Column<int>(type: "int", nullable: false),
                    PotenciaSalida = table.Column<double>(type: "float", nullable: false),
                    NumeroMPPT = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inversor", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bateria");

            migrationBuilder.DropTable(
                name: "Inversor");
        }
    }
}
