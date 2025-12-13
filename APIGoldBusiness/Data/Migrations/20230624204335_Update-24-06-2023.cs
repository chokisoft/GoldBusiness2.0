using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldBusiness.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update24062023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ErroresVenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperacionesDetalle = table.Column<int>(type: "int", nullable: false),
                    Localidad = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Costo = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ImporteCosto = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Servicio = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErroresVenta", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ErroresVenta");
        }
    }
}
