using Logstore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logstore.Domain.Entities
{
    public class Pedido : IEntityBase
    {
        public Guid Id { get; private set; }

        public int NumeroPedido { get; private set; }

        public ICollection<Pizza> Pizzas { get; private set; } = new List<Pizza>();

        public Pedido()
        {

        }

        public bool PedidoValido()
        {
            return this.Pizzas.Count > 0 && this.Pizzas.Count <= 10;
        }
    }
}
