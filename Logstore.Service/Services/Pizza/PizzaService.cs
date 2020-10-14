using Logstore.Domain.Entities;
using Logstore.Service.Interfaces.Pizza;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Service.Services.Pizza
{
    public class PizzaService : IPizzaService
    {
        public PizzaService()
        {

        }

        async Task<ICollection<PizzaSabores>> IPizzaService.GetCardapioPizzas()
        {
            return new List<PizzaSabores>();
        }
    }
}
