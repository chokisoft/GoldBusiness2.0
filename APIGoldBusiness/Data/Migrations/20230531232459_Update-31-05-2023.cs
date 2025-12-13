using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldBusiness.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update31052023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Establecimiento",
                table: "OperacionesEncabezado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OperacionesEncabezado_Establecimiento",
                table: "OperacionesEncabezado",
                column: "Establecimiento");

            migrationBuilder.AddForeignKey(
                name: "FK_OperacionesEncabezado_Establecimiento",
                table: "OperacionesEncabezado",
                column: "Establecimiento",
                principalTable: "Establecimiento",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperacionesEncabezado_Establecimiento",
                table: "OperacionesEncabezado");

            migrationBuilder.DropIndex(
                name: "IX_OperacionesEncabezado_Establecimiento",
                table: "OperacionesEncabezado");

            migrationBuilder.DropColumn(
                name: "Establecimiento",
                table: "OperacionesEncabezado");
        }
    }
}
