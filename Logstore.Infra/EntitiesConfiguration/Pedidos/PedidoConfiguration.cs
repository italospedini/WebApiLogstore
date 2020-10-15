using Logstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logstore.Infra.EntitiesConfiguration.Pedidos
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.IdCliente).IsRequired();
            builder.Property(x => x.Data_Pedido).IsRequired();
            builder.Property(x => x.ValorTotalPedido).IsRequired();

            builder.HasOne(x => x.Cliente).WithMany().HasForeignKey(x => x.IdCliente);

            builder.HasMany(x => x.Pizzas).WithOne(x => x.Pedido).HasForeignKey(x => x.IdPedido);
        }
    }
}
