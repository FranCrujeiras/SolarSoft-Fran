using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarSoft_1._0.Migrations
{
    /// <inheritdoc />
    public partial class InicializacionDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paneles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LONGITUDPANEL = table.Column<double>(type: "float", nullable: false),
                    ANCHOPANEL = table.Column<double>(type: "float", nullable: false),
                    POTENCIA = table.Column<int>(type: "int", nullable: false),
                    VOLTAJE = table.Column<double>(type: "float", nullable: false),
                    LATITUD = table.Column<double>(type: "float", nullable: false),
                    LONGITUD = table.Column<double>(type: "float", nullable: false),
                    LARGOTERRENO = table.Column<double>(type: "float", nullable: false),
                    ANCHOTERRENO = table.Column<double>(type: "float", nullable: false),
                    ANGULOESTRUCTURA = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paneles", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paneles");
        }
    }
}
