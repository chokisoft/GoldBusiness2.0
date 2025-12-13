using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldBusiness.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update30062023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Existencia",
                table: "Saldo",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,3)");

            migrationBuilder.CreateTable(
                name: "Moneda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Establecimiento = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Cancelado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraCreado = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraModificado = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moneda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moneda_Establecimiento",
                        column: x => x.Establecimiento,
                        principalTable: "Establecimiento",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Moneda",
                table: "Moneda",
                columns: new[] { "Establecimiento", "Codigo", "Cancelado" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moneda");

            migrationBuilder.AlterColumn<decimal>(
                name: "Existencia",
                table: "Saldo",
                type: "numeric(18,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");
        }
    }
}
