using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldBusiness.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update23062023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperacionesServicio_OperacionesDetalle_OperacionesDetalleNavigationId",
                table: "OperacionesServicio");

            migrationBuilder.DropIndex(
                name: "IX_OperacionesServicio_OperacionesDetalleNavigationId",
                table: "OperacionesServicio");

            migrationBuilder.DropColumn(
                name: "OperacionesDetalleNavigationId",
                table: "OperacionesServicio");

            migrationBuilder.AlterColumn<decimal>(
                name: "ImporteCosto",
                table: "OperacionesServicio",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Costo",
                table: "OperacionesServicio",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cantidad",
                table: "OperacionesServicio",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,3)");

            migrationBuilder.AddForeignKey(
                name: "FK_OperacionesServicio_OperacionesDetalle",
                table: "OperacionesServicio",
                column: "OperacionesDetalle",
                principalTable: "OperacionesDetalle",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperacionesServicio_OperacionesDetalle",
                table: "OperacionesServicio");

            migrationBuilder.AlterColumn<decimal>(
                name: "ImporteCosto",
                table: "OperacionesServicio",
                type: "numeric(18,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Costo",
                table: "OperacionesServicio",
                type: "numeric(18,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cantidad",
                table: "OperacionesServicio",
                type: "numeric(18,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "OperacionesDetalleNavigationId",
                table: "OperacionesServicio",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperacionesServicio_OperacionesDetalleNavigationId",
                table: "OperacionesServicio",
                column: "OperacionesDetalleNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_OperacionesServicio_OperacionesDetalle_OperacionesDetalleNavigationId",
                table: "OperacionesServicio",
                column: "OperacionesDetalleNavigationId",
                principalTable: "OperacionesDetalle",
                principalColumn: "Id");
        }
    }
}
