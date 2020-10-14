using Logstore.Domain.Entities;
using Logstore.Infra.Repositories.Interfaces.Pizza;
using Logstore.Service.Interfaces.Pizza;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Service.Services.Pizza
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaSaboresRepository _pizzaSaboresRepository;
     
        public PizzaService(IPizzaSaboresRepository pizzaSabores)
        {
            this._pizzaSaboresRepository = pizzaSabores;
        }

        async Task<ICollection<PizzaSabores>> IPizzaService.GetCardapio()
        {
            return await _pizzaSaboresRepository.GetCardapio();
        }

        async Task<PizzaSabores> IPizzaService.Cadastrar(PizzaSabores pizza)
        {
            return await _pizzaSaboresRepository.Add(pizza);
        }
    }
}
