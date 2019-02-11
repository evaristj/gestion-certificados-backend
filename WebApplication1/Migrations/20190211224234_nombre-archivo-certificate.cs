using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiGTT.Migrations
{
    public partial class nombrearchivocertificate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nombre_archivo",
                table: "Certificates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nombre_archivo",
                table: "Certificates");
        }
    }
}
