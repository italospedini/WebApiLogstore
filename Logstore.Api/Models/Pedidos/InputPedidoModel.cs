using Logstore.Api.Models.Mappings.Pizza;
using Logstore.Api.Models.Pizza;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Logstore.Api.Models.Pedidos
{
    public class InputPedidoModel
    {
        [Required]
        public int IdCliente { get; set; }

        public ICollection<InputPizzaPedidoModel> Pizzas { get; set; } = new List<InputPizzaPedidoModel>();
    }
}
