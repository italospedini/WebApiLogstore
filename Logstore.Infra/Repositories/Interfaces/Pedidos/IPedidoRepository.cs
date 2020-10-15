using Logstore.Domain.Entities;
using Logstore.Infra.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Infra.Repositories.Interfaces.Pedidos
{
    public interface IPedidoRepository : IBaseRepository<Pedido>
    {
        Task<ICollection<Pedido>> GetHistorico(int idCliente);
        Task<Pedido> GetByNumeroPedido(int numeroPedido);
    }
}
