using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldBusiness.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update02072023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PagoElectronicoParcialMlc",
                table: "CuentaCobrarPagar",
                newName: "PagoElectronicoParcialMLC");

            migrationBuilder.RenameColumn(
                name: "PagoEfectivoParcialMlc",
                table: "CuentaCobrarPagar",
                newName: "PagoEfectivoParcialMLC");

            migrationBuilder.RenameColumn(
                name: "CobroElectronicoParcialMlc",
                table: "CuentaCobrarPagar",
                newName: "CobroElectronicoParcialMLC");

            migrationBuilder.RenameColumn(
                name: "CobroEfectivoParcialMlc",
                table: "CuentaCobrarPagar",
                newName: "CobroEfectivoParcialMLC");

            migrationBuilder.AlterColumn<decimal>(
                name: "CobroEfectivoImporte",
                table: "CuentaCobrarPagar",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PagoElectronicoParcialMLC",
                table: "CuentaCobrarPagar",
                newName: "PagoElectronicoParcialMlc");

            migrationBuilder.RenameColumn(
                name: "PagoEfectivoParcialMLC",
                table: "CuentaCobrarPagar",
                newName: "PagoEfectivoParcialMlc");

            migrationBuilder.RenameColumn(
                name: "CobroElectronicoParcialMLC",
                table: "CuentaCobrarPagar",
                newName: "CobroElectronicoParcialMlc");

            migrationBuilder.RenameColumn(
                name: "CobroEfectivoParcialMLC",
                table: "CuentaCobrarPagar",
                newName: "CobroEfectivoParcialMlc");

            migrationBuilder.AlterColumn<string>(
                name: "CobroEfectivoImporte",
                table: "CuentaCobrarPagar",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }
    }
}
