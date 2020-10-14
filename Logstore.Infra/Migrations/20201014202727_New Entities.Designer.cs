﻿// <auto-generated />
using System;
using Logstore.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Logstore.Infra.Migrations
{
    [DbContext(typeof(LogstoreDbContext))]
    [Migration("20201014202727_New Entities")]
    partial class NewEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("LogstoreAPI")
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity("Logstore.Domain.Entities.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data_Pedido");

                    b.Property<int>("IdCliente");

                    b.Property<int>("NumeroPedido");

                    b.Property<decimal>("ValorTotalPedido");

                    b.HasKey("Id");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("Logstore.Domain.Entities.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdPedido");

                    b.Property<int>("IdPizzaSabor1");

                    b.Property<int>("IdPizzaSabor2");

                    b.Property<int?>("Sabor2Id");

                    b.HasKey("Id");

                    b.HasIndex("IdPedido");

                    b.HasIndex("IdPizzaSabor1");

                    b.HasIndex("Sabor2Id");

                    b.ToTable("Pizza");
                });

            modelBuilder.Entity("Logstore.Domain.Entities.PizzaSabores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativa");

                    b.Property<bool>("Disponivel");

                    b.Property<string>("NomeSabor")
                        .IsRequired();

                    b.Property<decimal>("PrecoUnitario");

                    b.HasKey("Id");

                    b.ToTable("PizzaSabores");
                });

            modelBuilder.Entity("Logstore.Domain.Entities.Pizza", b =>
                {
                    b.HasOne("Logstore.Domain.Entities.Pedido", "Pedido")
                        .WithMany("Pizzas")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Logstore.Domain.Entities.PizzaSabores", "Sabor1")
                        .WithMany()
                        .HasForeignKey("IdPizzaSabor1")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Logstore.Domain.Entities.PizzaSabores", "Sabor2")
                        .WithMany()
                        .HasForeignKey("Sabor2Id");
                });
#pragma warning restore 612, 618
        }
    }
}