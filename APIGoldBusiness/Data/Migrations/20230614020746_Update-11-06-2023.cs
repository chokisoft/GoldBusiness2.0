using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldBusiness.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update11062023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comprobante_Cuenta",
                table: "Comprobante");

            migrationBuilder.DropIndex(
                name: "IX_Comprobante_Cuenta",
                table: "Comprobante");

            migrationBuilder.DropColumn(
                name: "Credito",
                table: "Comprobante");

            migrationBuilder.DropColumn(
                name: "Cuenta",
                table: "Comprobante");

            migrationBuilder.DropColumn(
                name: "Debito",
                table: "Comprobante");

            migrationBuilder.DropColumn(
                name: "Departamento",
                table: "Comprobante");

            migrationBuilder.CreateTable(
                name: "ComprobanteDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comprobante = table.Column<int>(type: "int", nullable: false),
                    Cuenta = table.Column<int>(type: "int", nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    Debito = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Credito = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nota = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Cancelado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraCreado = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraModificado = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprobanteDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComprobanteDetalle_Comprobante",
                        column: x => x.Comprobante,
                        principalTable: "Comprobante",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComprobanteDetalle_Cuenta",
                        column: x => x.Cuenta,
                        principalTable: "Cuenta",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComprobanteDetalle_Comprobante",
                table: "ComprobanteDetalle",
                column: "Comprobante");

            migrationBuilder.CreateIndex(
                name: "IX_ComprobanteDetalle_Cuenta",
                table: "ComprobanteDetalle",
                column: "Cuenta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComprobanteDetalle");

            migrationBuilder.AddColumn<decimal>(
                name: "Credito",
                table: "Comprobante",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Cuenta",
                table: "Comprobante",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Debito",
                table: "Comprobante",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Departamento",
                table: "Comprobante",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comprobante_Cuenta",
                table: "Comprobante",
                column: "Cuenta");

            migrationBuilder.AddForeignKey(
                name: "FK_Comprobante_Cuenta",
                table: "Comprobante",
                column: "Cuenta",
                principalTable: "Cuenta",
                principalColumn: "Id");
        }
    }
}
