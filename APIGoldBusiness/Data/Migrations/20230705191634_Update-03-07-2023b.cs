using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldBusiness.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update03072023b : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EstadoCuenta",
                table: "EstadoCuenta");

            migrationBuilder.DropIndex(
                name: "IX_EstadoCuenta_Establecimiento",
                table: "EstadoCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoCuenta",
                table: "EstadoCuenta",
                columns: new[] { "Establecimiento", "Cuenta", "Departamento" },
                unique: true,
                filter: "[Departamento] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoCuenta_Cuenta",
                table: "EstadoCuenta",
                column: "Cuenta");

            migrationBuilder.CreateIndex(
                name: "IX_ErroresVenta_Codigo",
                table: "ErroresVenta",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_ErroresVenta_Localidad",
                table: "ErroresVenta",
                column: "Localidad");

            migrationBuilder.CreateIndex(
                name: "IX_ErroresVenta_OperacionesDetalle",
                table: "ErroresVenta",
                column: "OperacionesDetalle");

            migrationBuilder.AddForeignKey(
                name: "FK_ErroresVenta_Localidad",
                table: "ErroresVenta",
                column: "Localidad",
                principalTable: "Localidad",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ErroresVenta_OperacionesDetalle",
                table: "ErroresVenta",
                column: "OperacionesDetalle",
                principalTable: "OperacionesDetalle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ErroresVenta_Producto",
                table: "ErroresVenta",
                column: "Codigo",
                principalTable: "Producto",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ErroresVenta_Localidad",
                table: "ErroresVenta");

            migrationBuilder.DropForeignKey(
                name: "FK_ErroresVenta_OperacionesDetalle",
                table: "ErroresVenta");

            migrationBuilder.DropForeignKey(
                name: "FK_ErroresVenta_Producto",
                table: "ErroresVenta");

            migrationBuilder.DropIndex(
                name: "IX_EstadoCuenta",
                table: "EstadoCuenta");

            migrationBuilder.DropIndex(
                name: "IX_EstadoCuenta_Cuenta",
                table: "EstadoCuenta");

            migrationBuilder.DropIndex(
                name: "IX_ErroresVenta_Codigo",
                table: "ErroresVenta");

            migrationBuilder.DropIndex(
                name: "IX_ErroresVenta_Localidad",
                table: "ErroresVenta");

            migrationBuilder.DropIndex(
                name: "IX_ErroresVenta_OperacionesDetalle",
                table: "ErroresVenta");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoCuenta",
                table: "EstadoCuenta",
                columns: new[] { "Cuenta", "Departamento" },
                unique: true,
                filter: "[Departamento] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoCuenta_Establecimiento",
                table: "EstadoCuenta",
                column: "Establecimiento");
        }
    }
}
