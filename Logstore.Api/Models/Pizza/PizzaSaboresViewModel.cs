using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logstore.Api.Models.Pizza
{
    public class PizzaSaboresViewModel
    {
        public Guid Id { get; private set; }

        public string NomeSabor { get; private set; }

        public decimal PrecoUnitario { get; private set; }

    }
}
