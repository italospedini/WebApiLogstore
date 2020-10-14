using Logstore.Domain.Entities;
using Logstore.Infra.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Infra.Repositories.Interfaces.Pizza
{
    public interface IPizzaSaboresRepository : IBaseRepository<PizzaSabores>
    {
        Task<ICollection<PizzaSabores>> GetCardapio();
        Task<ICollection<PizzaSabores>> GetPizzasByIds(IEnumerable<int> idsPizzas);
    }
}