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
        public int IdCliente { get; set; }

        public string Endereco_Entrega { get; set; }

        public ICollection<InputPizzaPedidoModel> Pizzas { get; set; } = new List<InputPizzaPedidoModel>();

        public bool ModelIsValid()
        {
            if (IdCliente > 0)
                return true;

            if (string.IsNullOrWhiteSpace(Endereco_Entrega))
                return false;

            return true;
        }
    }
}
