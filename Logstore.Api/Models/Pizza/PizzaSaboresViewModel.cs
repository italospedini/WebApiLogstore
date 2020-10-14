using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Logstore.Api.Models.Pizza
{
    public class PizzaSaboresViewModel
    {
        public int Id { get; set; }

        [Required]
        public string NomeSabor { get; set; }

        [Required]
        public decimal PrecoUnitario { get; set; }

    }
}
