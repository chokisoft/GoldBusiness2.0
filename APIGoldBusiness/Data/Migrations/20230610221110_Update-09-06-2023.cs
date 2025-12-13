using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldBusiness.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update09062023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Departamento",
                table: "ComprobanteTemporal",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Establecimiento",
                table: "ComprobanteTemporal",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Departamento",
                table: "Comprobante",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Establecimiento",
                table: "Comprobante",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ComprobanteTemporal_Establecimiento",
                table: "ComprobanteTemporal",
                column: "Establecimiento");

            migrationBuilder.CreateIndex(
                name: "IX_Comprobante_Establecimiento",
                table: "Comprobante",
                column: "Establecimiento");

            migrationBuilder.AddForeignKey(
                name: "FK_Comprobante_Establecimiento",
                table: "Comprobante",
                column: "Establecimiento",
                principalTable: "Establecimiento",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComprobanteTemporal_Establecimiento",
                table: "ComprobanteTemporal",
                column: "Establecimiento",
                principalTable: "Establecimiento",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comprobante_Establecimiento",
                table: "Comprobante");

            migrationBuilder.DropForeignKey(
                name: "FK_ComprobanteTemporal_Establecimiento",
                table: "ComprobanteTemporal");

            migrationBuilder.DropIndex(
                name: "IX_ComprobanteTemporal_Establecimiento",
                table: "ComprobanteTemporal");

            migrationBuilder.DropIndex(
                name: "IX_Comprobante_Establecimiento",
                table: "Comprobante");

            migrationBuilder.DropColumn(
                name: "Establecimiento",
                table: "ComprobanteTemporal");

            migrationBuilder.DropColumn(
                name: "Establecimiento",
                table: "Comprobante");

            migrationBuilder.AlterColumn<string>(
                name: "Departamento",
                table: "ComprobanteTemporal",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Departamento",
                table: "Comprobante",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8,
                oldNullable: true);
        }
    }
}
