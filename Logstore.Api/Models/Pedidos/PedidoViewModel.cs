using Logstore.Api.Models.Pizza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logstore.Api.Models.Pedidos
{
    public class PedidoViewModel
    {
        public int Id { get; set; }

        public int NumeroPedido { get; set; }

        public int IdCliente { get; set; }

        public DateTime Data_Pedido { get; set; }

        public ICollection<PizzaViewModel> Pizzas { get; set; } = new List<PizzaViewModel>();

        public Decimal ValorTotalPedido { get; set; }
    }
}
