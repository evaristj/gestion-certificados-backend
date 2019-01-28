using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiGTT.Migrations
{
    public partial class UpdateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    alias = table.Column<string>(nullable: true),
                    entidad_emisora = table.Column<string>(nullable: true),
                    num_serie = table.Column<string>(nullable: true),
                    subject = table.Column<string>(nullable: true),
                    caducidad = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    id_orga = table.Column<string>(nullable: true),
                    nombre_cliente = table.Column<string>(nullable: true),
                    contacto_renovacion = table.Column<string>(nullable: true),
                    repositorio_url = table.Column<string>(nullable: true),
                    observaciones = table.Column<string>(nullable: true),
                    integration_list = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Jira",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    project = table.Column<string>(nullable: true),
                    component = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jira", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "Jira");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
