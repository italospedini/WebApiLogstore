using Logstore.Domain.Entities;
using Logstore.Infra.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Infra.Repositories.Interfaces.Clientes
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Task<bool> ClienteExiste(int idCliente);
    }
}
