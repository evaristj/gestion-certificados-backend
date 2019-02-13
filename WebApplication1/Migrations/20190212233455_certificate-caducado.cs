using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiGTT.Migrations
{
    public partial class certificatecaducado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "caducado",
                table: "Certificates",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "proxCaducidad",
                table: "Certificates",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "caducado",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "proxCaducidad",
                table: "Certificates");
        }
    }
}
