using Microsoft.EntityFrameworkCore.Migrations;

namespace Logstore.Infra.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "LogstoreAPI");

            migrationBuilder.CreateTable(
                name: "PizzaSabores",
                schema: "LogstoreAPI",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeSabor = table.Column<string>(nullable: false),
                    PrecoUnitario = table.Column<decimal>(nullable: false),
                    Disponivel = table.Column<bool>(nullable: false),
                    Ativa = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaSabores", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaSabores",
                schema: "LogstoreAPI");
        }
    }
}
