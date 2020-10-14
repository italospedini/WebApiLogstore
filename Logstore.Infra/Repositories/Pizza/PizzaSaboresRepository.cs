using Logstore.Domain.Entities;
using Logstore.Infra.Base;
using Logstore.Infra.Context;
using Logstore.Infra.Repositories.Interfaces.Pizza;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Infra.Repositories.Pizza
{
    public class PizzaSaboresRepository : BaseRepository<PizzaSabores, LogstoreDbContext>, IPizzaSaboresRepository
    {
        private LogstoreDbContext _context;

        public PizzaSaboresRepository(LogstoreDbContext context) : base(context)
        {
            this._context = context;
        }

        async Task<ICollection<PizzaSabores>> IPizzaSaboresRepository.GetCardapio()
        {
            return await _context.PizzaSabores
                            .AsNoTracking()
                            .Where(x => x.Ativa)
                            .ToListAsync();
        }
    }
}