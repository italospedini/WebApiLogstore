using Logstore.Api.Models.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logstore.Api.Models.Pizza
{
    public class PizzaViewModel
    {
        public int Id { get; set; }

        public int IdPizzaSabor1 { get; set; }

        public PizzaSaboresViewModel Sabor1 { get; set; }

        public int? IdPizzaSabor2 { get; set; }

        public PizzaSaboresViewModel Sabor2 { get; set; }

        public int IdPedido { get; set; }

        public PedidoViewModel Pedido { get; set; }

    }
}
