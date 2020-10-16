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

            // Insert data to PizzaSabores Table
            migrationBuilder.InsertData("PizzaSabores", new string[] { "Id", "NomeSabor", "Disponivel", "Ativa", "PrecoUnitario" },
                new object[] { 1, "3 Queijos", 1, 1, 50.0 });

            migrationBuilder.InsertData("PizzaSabores", new string[] { "Id", "NomeSabor", "Disponivel", "Ativa", "PrecoUnitario" },
                new object[] { 2, "Frango com requeijão", 1, 1, 59.99 });

            migrationBuilder.InsertData("PizzaSabores", new string[] { "Id", "NomeSabor", "Disponivel", "Ativa", "PrecoUnitario" },
                new object[] { 3, "Mussarela", 1, 1, 42.5 });

            migrationBuilder.InsertData("PizzaSabores", new string[] { "Id", "NomeSabor", "Disponivel", "Ativa", "PrecoUnitario" },
                new object[] { 4, "Calabresa", 1, 1, 42.5 });

            migrationBuilder.InsertData("PizzaSabores", new string[] { "Id", "NomeSabor", "Disponivel", "Ativa", "PrecoUnitario" },
                new object[] { 5, "Pepperoni", 1, 1, 55.0 });

            migrationBuilder.InsertData("PizzaSabores", new string[] { "Id", "NomeSabor", "Disponivel", "Ativa", "PrecoUnitario" },
                new object[] { 6, "Portuguesa", 1, 1, 45.0 });

            migrationBuilder.InsertData("PizzaSabores", new string[] { "Id", "NomeSabor", "Disponivel", "Ativa", "PrecoUnitario" },
                new object[] { 7, "Veggie", 1, 1, 59.99 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaSabores",
                schema: "LogstoreAPI");
        }
    }
}
