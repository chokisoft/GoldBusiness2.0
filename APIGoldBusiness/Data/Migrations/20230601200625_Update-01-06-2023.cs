using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldBusiness.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update01062023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OperacionesEncabezado",
                table: "OperacionesEncabezado");

            migrationBuilder.DropIndex(
                name: "IX_OperacionesEncabezado_Establecimiento",
                table: "OperacionesEncabezado");

            migrationBuilder.CreateIndex(
                name: "IX_OperacionesEncabezado",
                table: "OperacionesEncabezado",
                columns: new[] { "Establecimiento", "Transaccion", "NoDocumento", "Cancelado" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperacionesEncabezado_Transaccion",
                table: "OperacionesEncabezado",
                column: "Transaccion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OperacionesEncabezado",
                table: "OperacionesEncabezado");

            migrationBuilder.DropIndex(
                name: "IX_OperacionesEncabezado_Transaccion",
                table: "OperacionesEncabezado");

            migrationBuilder.CreateIndex(
                name: "IX_OperacionesEncabezado",
                table: "OperacionesEncabezado",
                columns: new[] { "Transaccion", "NoDocumento", "Cancelado" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperacionesEncabezado_Establecimiento",
                table: "OperacionesEncabezado",
                column: "Establecimiento");
        }
    }
}
