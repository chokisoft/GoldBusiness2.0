using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldBusiness.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update03062023e : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstadoCuenta_Establecimiento_EstablecimientoNavigationId",
                table: "EstadoCuenta");

            migrationBuilder.DropIndex(
                name: "IX_EstadoCuenta_EstablecimientoNavigationId",
                table: "EstadoCuenta");

            migrationBuilder.DropColumn(
                name: "EstablecimientoNavigationId",
                table: "EstadoCuenta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstablecimientoNavigationId",
                table: "EstadoCuenta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EstadoCuenta_EstablecimientoNavigationId",
                table: "EstadoCuenta",
                column: "EstablecimientoNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_EstadoCuenta_Establecimiento_EstablecimientoNavigationId",
                table: "EstadoCuenta",
                column: "EstablecimientoNavigationId",
                principalTable: "Establecimiento",
                principalColumn: "Id");
        }
    }
}
