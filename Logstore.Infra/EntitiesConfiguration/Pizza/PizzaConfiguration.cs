using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logstore.Infra.EntitiesConfiguration.Pizza
{
    public class PizzaConfiguration : IEntityTypeConfiguration<Logstore.Domain.Entities.Pizza>
    {
        public void Configure(EntityTypeBuilder<Logstore.Domain.Entities.Pizza> builder)
        {
            builder.ToTable("Pizzas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.IdPedido).IsRequired();
            builder.Property(x => x.IdPizzaSabor1).IsRequired();
            builder.Property(x => x.IdPizzaSabor2);

            builder.HasOne(x => x.Pedido).WithMany(x => x.Pizzas).HasForeignKey(x => x.IdPedido);

            builder.HasOne(x => x.Sabor1).WithMany().HasForeignKey(x => x.IdPizzaSabor1);
            builder.HasOne(x => x.Sabor2).WithMany().HasForeignKey(x => x.IdPizzaSabor2);
        }
    }
}
