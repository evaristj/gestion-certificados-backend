using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiGTT.Migrations
{
    public partial class camposdbactualizados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_id",
                table: "Certificates");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Jira",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "issueType",
                table: "Jira",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "Jira");

            migrationBuilder.DropColumn(
                name: "issueType",
                table: "Jira");

            migrationBuilder.AddColumn<long>(
                name: "user_id",
                table: "Certificates",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
