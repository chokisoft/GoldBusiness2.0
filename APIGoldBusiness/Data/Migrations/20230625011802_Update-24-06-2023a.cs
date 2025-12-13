using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldBusiness.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update24062023a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Establecimiento",
                table: "EstadoCuenta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EstadoCuenta_Establecimiento",
                table: "EstadoCuenta",
                column: "Establecimiento");

            migrationBuilder.AddForeignKey(
                name: "FK_EstadoCuenta_Establecimiento",
                table: "EstadoCuenta",
                column: "Establecimiento",
                principalTable: "Establecimiento",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstadoCuenta_Establecimiento",
                table: "EstadoCuenta");

            migrationBuilder.DropIndex(
                name: "IX_EstadoCuenta_Establecimiento",
                table: "EstadoCuenta");

            migrationBuilder.DropColumn(
                name: "Establecimiento",
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
        }
    }
}
