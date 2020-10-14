using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Logstore.Infra.Migrations
{
    public partial class Pedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedido",
                schema: "LogstoreAPI",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumeroPedido = table.Column<int>(nullable: false),
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Data_Pedido = table.Column<DateTime>(nullable: false),
                    ValorTotalPedido = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pizza",
                schema: "LogstoreAPI",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdPizzaSabor1 = table.Column<int>(nullable: false),
                    IdPizzaSabor2 = table.Column<int>(nullable: true),
                    IdPedido = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pizza_Pedido_IdPedido",
                        column: x => x.IdPedido,
                        principalSchema: "LogstoreAPI",
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pizza_PizzaSabores_IdPizzaSabor1",
                        column: x => x.IdPizzaSabor1,
                        principalSchema: "LogstoreAPI",
                        principalTable: "PizzaSabores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pizza_PizzaSabores_IdPizzaSabor2",
                        column: x => x.IdPizzaSabor2,
                        principalSchema: "LogstoreAPI",
                        principalTable: "PizzaSabores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_IdPedido",
                schema: "LogstoreAPI",
                table: "Pizza",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_IdPizzaSabor1",
                schema: "LogstoreAPI",
                table: "Pizza",
                column: "IdPizzaSabor1");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_IdPizzaSabor2",
                schema: "LogstoreAPI",
                table: "Pizza",
                column: "IdPizzaSabor2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pizza",
                schema: "LogstoreAPI");

            migrationBuilder.DropTable(
                name: "Pedido",
                schema: "LogstoreAPI");
        }
    }
}
