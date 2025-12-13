using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldBusiness.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update01072023b : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuentaCobrarPagar_Localidad_LocalidadId",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropIndex(
                name: "IX_CuentaCobrarPagar_LocalidadId",
                table: "CuentaCobrarPagar");

            migrationBuilder.DropColumn(
                name: "LocalidadId",
                table: "CuentaCobrarPagar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocalidadId",
                table: "CuentaCobrarPagar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CuentaCobrarPagar_LocalidadId",
                table: "CuentaCobrarPagar",
                column: "LocalidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_CuentaCobrarPagar_Localidad_LocalidadId",
                table: "CuentaCobrarPagar",
                column: "LocalidadId",
                principalTable: "Localidad",
                principalColumn: "Id");
        }
    }
}
