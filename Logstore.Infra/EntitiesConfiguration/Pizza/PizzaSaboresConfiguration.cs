using Logstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logstore.Infra.EntitiesConfiguration.Pizza
{
    public class PizzaSaboresConfiguration : IEntityTypeConfiguration<PizzaSabores>
    {
        public void Configure(EntityTypeBuilder<PizzaSabores> builder)
        {
            builder.ToTable("PizzaSabores");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.NomeSabor).IsRequired();
            builder.Property(x => x.PrecoUnitario).IsRequired();
            builder.Property(x => x.Disponivel).IsRequired();
            builder.Property(x => x.Ativa).IsRequired();
        }
    }
}
