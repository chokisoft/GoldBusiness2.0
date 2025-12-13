using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldBusiness.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update12062023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuentaCobrarPagar_Cuenta",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropForeignKey(
                name: "FK_CuentaCobrarPagar_Cuenta_CuentaCobroNavigationId",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropIndex(
                name: "IX_CuentaCobrarPagar_CuentaCobroNavigationId",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropColumn(
                name: "CuentaCobroNavigationId",
                table: "CuentaCobrarPagar");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaCobrarPagar_CuentaCobro",
                table: "CuentaCobrarPagar",
                column: "CuentaCobro");

            migrationBuilder.AddForeignKey(
                name: "FK_CuentaCobrarPagar_CuentaCobro",
                table: "CuentaCobrarPagar",
                column: "CuentaCobro",
                principalTable: "Cuenta",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CuentaCobrarPagar_CuentaPago",
                table: "CuentaCobrarPagar",
                column: "CuentaPago",
                principalTable: "Cuenta",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuentaCobrarPagar_CuentaCobro",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropForeignKey(
                name: "FK_CuentaCobrarPagar_CuentaPago",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropIndex(
                name: "IX_CuentaCobrarPagar_CuentaCobro",
                table: "CuentaCobrarPagar");

            migrationBuilder.AddColumn<int>(
                name: "CuentaCobroNavigationId",
                table: "CuentaCobrarPagar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CuentaCobrarPagar_CuentaCobroNavigationId",
                table: "CuentaCobrarPagar",
                column: "CuentaCobroNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CuentaCobrarPagar_Cuenta",
                table: "CuentaCobrarPagar",
                column: "CuentaPago",
                principalTable: "Cuenta",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CuentaCobrarPagar_Cuenta_CuentaCobroNavigationId",
                table: "CuentaCobrarPagar",
                column: "CuentaCobroNavigationId",
                principalTable: "Cuenta",
                principalColumn: "Id");
        }
    }
}
