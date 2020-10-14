using Logstore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logstore.Domain.Entities
{
    public class Pizza : IEntityBase
    {
        public Guid Id { get; private set; }

        public PizzaSabores Sabor1 { get; private set; }

        public PizzaSabores Sabor2 { get; private set; }

        public decimal PrecoTotal
        {
            get
            {
                if (this.Sabor2 != null)
                    return Sabor1.PrecoUnitario;

                return this.Sabor1.PrecoUnitario / 2 + this.Sabor2.PrecoUnitario / 2;
            }
        }

        public Pizza()
        {

        }

        public bool PizzaValida()
        {
            return this.Sabor1 != null;
        }
    }
}
