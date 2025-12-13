using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldBusiness.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update03072023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Parcial",
                table: "EstadoCuenta",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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

            migrationBuilder.AddColumn<decimal>(
                name: "Parcial",
                table: "ComprobanteTemporal",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Parcial",
                table: "ComprobanteDetalle",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Parcial",
                table: "EstadoCuenta");

            migrationBuilder.DropColumn(
                name: "Parcial",
                table: "ComprobanteTemporal");

            migrationBuilder.DropColumn(
                name: "Parcial",
                table: "ComprobanteDetalle");

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
        }
    }
}
