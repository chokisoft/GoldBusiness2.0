using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldBusiness.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update01072023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuentaCobrarPagar_CuentaCobro",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropForeignKey(
                name: "FK_CuentaCobrarPagar_CuentaPago",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropForeignKey(
                name: "FK_CuentaCobrarPagar_Localidad",
                table: "CuentaCobrarPagar");

            migrationBuilder.RenameColumn(
                name: "Localidad",
                table: "CuentaCobrarPagar",
                newName: "LocalidadId");

            migrationBuilder.RenameColumn(
                name: "CuentaPago",
                table: "CuentaCobrarPagar",
                newName: "CuentaPagoElectronico");

            migrationBuilder.RenameColumn(
                name: "CuentaCobro",
                table: "CuentaCobrarPagar",
                newName: "CuentaPagoEfectivo");

            migrationBuilder.RenameIndex(
                name: "IX_CuentaCobrarPagar_Localidad",
                table: "CuentaCobrarPagar",
                newName: "IX_CuentaCobrarPagar_LocalidadId");

            migrationBuilder.RenameIndex(
                name: "IX_CuentaCobrarPagar_CuentaPago",
                table: "CuentaCobrarPagar",
                newName: "IX_CuentaCobrarPagar_CuentaPagoElectronico");

            migrationBuilder.RenameIndex(
                name: "IX_CuentaCobrarPagar_CuentaCobro",
                table: "CuentaCobrarPagar",
                newName: "IX_CuentaCobrarPagar_CuentaPago");

            migrationBuilder.AddColumn<string>(
                name: "CobroEfectivoDepartamento",
                table: "CuentaCobrarPagar",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CobroEfectivoImporte",
                table: "CuentaCobrarPagar",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CobroEfectivoParcialMLC",
                table: "CuentaCobrarPagar",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CobroElectronicoDepartamento",
                table: "CuentaCobrarPagar",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CobroElectronicoImporte",
                table: "CuentaCobrarPagar",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CobroElectronicoParcialMLC",
                table: "CuentaCobrarPagar",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CuentaCobroEfectivo",
                table: "CuentaCobrarPagar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CuentaCobroElectronico",
                table: "CuentaCobrarPagar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Establecimiento",
                table: "CuentaCobrarPagar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PagoEfectivoDepartamento",
                table: "CuentaCobrarPagar",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PagoEfectivoImporte",
                table: "CuentaCobrarPagar",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PagoEfectivoParcialMLC",
                table: "CuentaCobrarPagar",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PagoElectronicoDepartamento",
                table: "CuentaCobrarPagar",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PagoElectronicoImporte",
                table: "CuentaCobrarPagar",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PagoElectronicoParcialMLC",
                table: "CuentaCobrarPagar",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CuentaCobrarPagar_CuentaCobroEfectivo",
                table: "CuentaCobrarPagar",
                column: "CuentaCobroEfectivo");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaCobrarPagar_CuentaCobroElectronico",
                table: "CuentaCobrarPagar",
                column: "CuentaCobroElectronico");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaCobrarPagar_Establecimiento",
                table: "CuentaCobrarPagar",
                column: "Establecimiento");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaCobrarPagar_Localidad",
                table: "CuentaCobrarPagar",
                column: "CobroEfectivoImporte");

            migrationBuilder.AddForeignKey(
                name: "FK_CuentaCobrarEfectivo_Cuenta",
                table: "CuentaCobrarPagar",
                column: "CuentaCobroEfectivo",
                principalTable: "Cuenta",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CuentaCobrarElectronico_Cuenta",
                table: "CuentaCobrarPagar",
                column: "CuentaCobroElectronico",
                principalTable: "Cuenta",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CuentaCobrarPagar_Establecimiento",
                table: "CuentaCobrarPagar",
                column: "Establecimiento",
                principalTable: "Establecimiento",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CuentaCobrarPagar_Localidad_LocalidadId",
                table: "CuentaCobrarPagar",
                column: "LocalidadId",
                principalTable: "Localidad",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CuentaPagarEfectivo_Cuenta",
                table: "CuentaCobrarPagar",
                column: "CuentaPagoEfectivo",
                principalTable: "Cuenta",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CuentaPagarElectronico_Cuenta",
                table: "CuentaCobrarPagar",
                column: "CuentaPagoElectronico",
                principalTable: "Cuenta",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuentaCobrarEfectivo_Cuenta",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropForeignKey(
                name: "FK_CuentaCobrarElectronico_Cuenta",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropForeignKey(
                name: "FK_CuentaCobrarPagar_Establecimiento",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropForeignKey(
                name: "FK_CuentaCobrarPagar_Localidad_LocalidadId",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropForeignKey(
                name: "FK_CuentaPagarEfectivo_Cuenta",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropForeignKey(
                name: "FK_CuentaPagarElectronico_Cuenta",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropIndex(
                name: "IX_CuentaCobrarPagar_CuentaCobroEfectivo",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropIndex(
                name: "IX_CuentaCobrarPagar_CuentaCobroElectronico",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropIndex(
                name: "IX_CuentaCobrarPagar_Establecimiento",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropIndex(
                name: "IX_CuentaCobrarPagar_Localidad",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropColumn(
                name: "CobroEfectivoDepartamento",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropColumn(
                name: "CobroEfectivoImporte",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropColumn(
                name: "CobroEfectivoParcialMLC",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropColumn(
                name: "CobroElectronicoDepartamento",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropColumn(
                name: "CobroElectronicoImporte",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropColumn(
                name: "CobroElectronicoParcialMLC",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropColumn(
                name: "CuentaCobroEfectivo",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropColumn(
                name: "CuentaCobroElectronico",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropColumn(
                name: "Establecimiento",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropColumn(
                name: "PagoEfectivoDepartamento",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropColumn(
                name: "PagoEfectivoImporte",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropColumn(
                name: "PagoEfectivoParcialMLC",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropColumn(
                name: "PagoElectronicoDepartamento",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropColumn(
                name: "PagoElectronicoImporte",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropColumn(
                name: "PagoElectronicoParcialMLC",
                table: "CuentaCobrarPagar");

            migrationBuilder.RenameColumn(
                name: "LocalidadId",
                table: "CuentaCobrarPagar",
                newName: "Localidad");

            migrationBuilder.RenameColumn(
                name: "CuentaPagoElectronico",
                table: "CuentaCobrarPagar",
                newName: "CuentaPago");

            migrationBuilder.RenameColumn(
                name: "CuentaPagoEfectivo",
                table: "CuentaCobrarPagar",
                newName: "CuentaCobro");

            migrationBuilder.RenameIndex(
                name: "IX_CuentaCobrarPagar_LocalidadId",
                table: "CuentaCobrarPagar",
                newName: "IX_CuentaCobrarPagar_Localidad");

            migrationBuilder.RenameIndex(
                name: "IX_CuentaCobrarPagar_CuentaPagoElectronico",
                table: "CuentaCobrarPagar",
                newName: "IX_CuentaCobrarPagar_CuentaPago");

            migrationBuilder.RenameIndex(
                name: "IX_CuentaCobrarPagar_CuentaPago",
                table: "CuentaCobrarPagar",
                newName: "IX_CuentaCobrarPagar_CuentaCobro");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CuentaCobrarPagar_Localidad",
                table: "CuentaCobrarPagar",
                column: "Localidad",
                principalTable: "Localidad",
                principalColumn: "Id");
        }
    }
}
