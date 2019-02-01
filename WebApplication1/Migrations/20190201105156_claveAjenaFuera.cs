using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiGTT.Migrations
{
    public partial class claveAjenaFuera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_Users_user_idid",
                table: "Certificates");

            migrationBuilder.DropForeignKey(
                name: "FK_Jira_Users_user_idid",
                table: "Jira");

            migrationBuilder.DropIndex(
                name: "IX_Jira_user_idid",
                table: "Jira");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_user_idid",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "user_idid",
                table: "Jira");

            migrationBuilder.DropColumn(
                name: "user_idid",
                table: "Certificates");

            migrationBuilder.AddColumn<long>(
                name: "user_id",
                table: "Jira",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "user_id",
                table: "Certificates",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_id",
                table: "Jira");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "Certificates");

            migrationBuilder.AddColumn<long>(
                name: "user_idid",
                table: "Jira",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "user_idid",
                table: "Certificates",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jira_user_idid",
                table: "Jira",
                column: "user_idid");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_user_idid",
                table: "Certificates",
                column: "user_idid");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_Users_user_idid",
                table: "Certificates",
                column: "user_idid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jira_Users_user_idid",
                table: "Jira",
                column: "user_idid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
