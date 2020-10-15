using Logstore.Domain.Entities;
using Logstore.Infra.Base;
using Logstore.Infra.Base.Interfaces;
using Logstore.Infra.Context;
using Logstore.Infra.Repositories.Interfaces.Clientes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Infra.Repositories.Clientes
{
    public class ClienteRepository : BaseRepository<Cliente, LogstoreDbContext>, IClienteRepository
    {
        private LogstoreDbContext _context;

        public ClienteRepository(LogstoreDbContext context) : base(context)
        {
            this._context = context;
        }

        async Task<bool> IClienteRepository.ClienteExiste(int idCliente)
        {
            return await _context.Clientes
                            .AsNoTracking()
                            .Where(x => x.Id.Equals(idCliente))
                            .AnyAsync();
        }

    }
}
