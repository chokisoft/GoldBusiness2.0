using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldBusiness.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update15062023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Localidad",
                table: "FichaProducto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FichaProducto_Localidad",
                table: "FichaProducto",
                column: "Localidad");

            migrationBuilder.AddForeignKey(
                name: "FK_FichaProducto_Localidad",
                table: "FichaProducto",
                column: "Localidad",
                principalTable: "Localidad",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FichaProducto_Localidad",
                table: "FichaProducto");

            migrationBuilder.DropIndex(
                name: "IX_FichaProducto_Localidad",
                table: "FichaProducto");

            migrationBuilder.DropColumn(
                name: "Localidad",
                table: "FichaProducto");
        }
    }
}
