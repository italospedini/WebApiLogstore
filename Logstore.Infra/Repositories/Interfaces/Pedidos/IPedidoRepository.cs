using Logstore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Infra.Repositories.Interfaces.Pedidos
{
    public interface IPedidoRepository
    {
        Task<ICollection<Pedido>> GetHistorico(int idCliente);
    }
}
