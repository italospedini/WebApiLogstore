using Logstore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Service.Interfaces.Pizza
{
    public interface IPizzaService
    {
        Task<ICollection<PizzaSabores>> GetCardapio();
        Task<PizzaSabores> Cadastrar(PizzaSabores pizza);
    }
}
