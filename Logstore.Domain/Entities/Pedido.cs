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
            
        }

        public bool PedidoValido()
        {
            return this.Pizzas.Count > 0 && this.Pizzas.Count <= 10;
        }

        public void CalcularValorTotal(ICollection<PizzaSabores> pizzas)
        {
            this.ValorTotalPedido = 0;

            foreach (var pizza in this.Pizzas)
            {
                if (pizza.IdPizzaSabor2 == null)
                    this.ValorTotalPedido += pizzas.FirstOrDefault(x => x.Id.Equals(pizza.IdPizzaSabor1)).PrecoUnitario;
                else
                    this.ValorTotalPedido += pizzas.FirstOrDefault(x => x.Id.Equals(pizza.IdPizzaSabor1)).PrecoUnitario / 2
                        + pizzas.FirstOrDefault(x => x.Id.Equals(pizza.IdPizzaSabor2)).PrecoUnitario / 2;
            }
        }

        public void Criar()
        {
            this.Data_Pedido = DateTime.Now;
        }

    }
}
