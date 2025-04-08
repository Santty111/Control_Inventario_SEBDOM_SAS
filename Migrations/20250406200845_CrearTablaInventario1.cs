using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Control_Inventario_SEBDOM_SAS.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablaInventario1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Entrada",
                table: "Balance");

            migrationBuilder.DropColumn(
                name: "Salida",
                table: "Balance");

            migrationBuilder.AddColumn<double>(
                name: "StockActual",
                table: "Balance",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockActual",
                table: "Balance");

            migrationBuilder.AddColumn<double>(
                name: "Entrada",
                table: "Balance",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Salida",
                table: "Balance",
                type: "float",
                nullable: true);
        }
    }
}
