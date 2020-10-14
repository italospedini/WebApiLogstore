using Logstore.Domain.Entities;
using Logstore.Infra.Base;
using Logstore.Infra.Context;
using Logstore.Infra.Repositories.Interfaces.Pedidos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Infra.Repositories.Pedidos
{
    public class PedidoRepository : BaseRepository<Pedido, LogstoreDbContext>, IPedidoRepository
    {
        private LogstoreDbContext _context;

        public PedidoRepository(LogstoreDbContext context) : base(context)
        {
            this._context = context;
        }

        async Task<ICollection<Pedido>> IPedidoRepository.GetHistorico(int idCliente)
        {
            return await _context.Pedidos
                            .AsNoTracking()
                            .Include(x => x.Pizzas).ThenInclude(x => x.Sabor1)
                            .Include(x => x.Pizzas).ThenInclude(x => x.Sabor2)
                            .Where(x => x.IdCliente.Equals(idCliente))
                            .ToListAsync();
        }
    }
}