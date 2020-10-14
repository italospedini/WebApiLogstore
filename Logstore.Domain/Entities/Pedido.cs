using Logstore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logstore.Domain.Entities
{
    public class Pedido : IEntityBase
    {
        public int Id { get; private set; }

        public int NumeroPedido { get; private set; }

        public int IdCliente { get; private set; }

        public DateTime Data_Pedido { get; private set; }

        public virtual ICollection<Pizza> Pizzas { get; private set; } = new List<Pizza>();

        public Decimal ValorTotalPedido { get; private set; }

        public Pedido()
        {
            this.Data_Pedido = DateTime.Now;
        }

        public bool PedidoValido()
        {
            return this.Pizzas.Count > 0 && this.Pizzas.Count <= 10;
        }

        public void CalcularValorTotalPedido()
        {
            this.ValorTotalPedido = 0;

            foreach (var pizza in this.Pizzas)
            {
                this.ValorTotalPedido += pizza.PrecoTotal;
            }
        }
    }
}
