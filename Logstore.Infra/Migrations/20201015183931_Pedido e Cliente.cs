using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Logstore.Infra.Migrations
{
    public partial class PedidoeCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                schema: "LogstoreAPI",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Endereco_Entrega = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                schema: "LogstoreAPI",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdCliente = table.Column<int>(nullable: false),
                    Data_Pedido = table.Column<DateTime>(nullable: false),
                    ValorTotalPedido = table.Column<decimal>(nullable: false),
                    Endereco_Entrega = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalSchema: "LogstoreAPI",
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
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
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pizzas_Pedidos_IdPedido",
                        column: x => x.IdPedido,
                        principalSchema: "LogstoreAPI",
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pizzas_PizzaSabores_IdPizzaSabor1",
                        column: x => x.IdPizzaSabor1,
                        principalSchema: "LogstoreAPI",
                        principalTable: "PizzaSabores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pizzas_PizzaSabores_IdPizzaSabor2",
                        column: x => x.IdPizzaSabor2,
                        principalSchema: "LogstoreAPI",
                        principalTable: "PizzaSabores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdCliente",
                schema: "LogstoreAPI",
                table: "Pedidos",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_IdPedido",
                schema: "LogstoreAPI",
                table: "Pizzas",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_IdPizzaSabor1",
                schema: "LogstoreAPI",
                table: "Pizzas",
                column: "IdPizzaSabor1");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_IdPizzaSabor2",
                schema: "LogstoreAPI",
                table: "Pizzas",
                column: "IdPizzaSabor2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pizzas",
                schema: "LogstoreAPI");

            migrationBuilder.DropTable(
                name: "Pedidos",
                schema: "LogstoreAPI");

            migrationBuilder.DropTable(
                name: "Clientes",
                schema: "LogstoreAPI");
        }
    }
}
