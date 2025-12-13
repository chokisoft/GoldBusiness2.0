using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldBusiness.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update30062024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Acceso_1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Acceso_2",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Acceso_3",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Accesos",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accesos",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Acceso_1",
                table: "AspNetUsers",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Acceso_2",
                table: "AspNetUsers",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Acceso_3",
                table: "AspNetUsers",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true);
        }
    }
}
