using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Logstore.Api.Models.Mappings.Pizza
{
    public class InputPizzaPedidoModel
    {
        [Required]
        public int IdPizzaSabor1 { get; set; }

        public int? IdPizzaSabor2 { get; set; }
    }
}
