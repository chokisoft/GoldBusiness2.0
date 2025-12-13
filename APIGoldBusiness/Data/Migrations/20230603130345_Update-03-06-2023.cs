using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldBusiness.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update03062023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstadoCuenta_Establecimiento",
                table: "EstadoCuenta");

            migrationBuilder.DropIndex(
                name: "IX_EstadoCuenta_Cuenta",
                table: "EstadoCuenta");

            migrationBuilder.DropIndex(
                name: "IX_EstadoCuenta_Cuenta1",
                table: "EstadoCuenta");

            migrationBuilder.DropColumn(
                name: "Establecimiento",
                table: "EstadoCuenta");

            migrationBuilder.AlterColumn<string>(
                name: "Departamento",
                table: "EstadoCuenta",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstablecimientoNavigationId",
                table: "EstadoCuenta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EstadoCuenta",
                table: "EstadoCuenta",
                columns: new[] { "Cuenta", "Departamento" },
                unique: true,
                filter: "[Departamento] IS NOT NULL");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstadoCuenta_Establecimiento_EstablecimientoNavigationId",
                table: "EstadoCuenta");

            migrationBuilder.DropIndex(
                name: "IX_EstadoCuenta",
                table: "EstadoCuenta");

            migrationBuilder.DropIndex(
                name: "IX_EstadoCuenta_EstablecimientoNavigationId",
                table: "EstadoCuenta");

            migrationBuilder.DropColumn(
                name: "EstablecimientoNavigationId",
                table: "EstadoCuenta");

            migrationBuilder.AlterColumn<string>(
                name: "Departamento",
                table: "EstadoCuenta",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Establecimiento",
                table: "EstadoCuenta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EstadoCuenta_Cuenta",
                table: "EstadoCuenta",
                columns: new[] { "Establecimiento", "Cuenta" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EstadoCuenta_Cuenta1",
                table: "EstadoCuenta",
                column: "Cuenta");

            migrationBuilder.AddForeignKey(
                name: "FK_EstadoCuenta_Establecimiento",
                table: "EstadoCuenta",
                column: "Establecimiento",
                principalTable: "Establecimiento",
                principalColumn: "Id");
        }
    }
}
