using Logstore.Domain.Interfaces;
using Logstore.Infra.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Infra.Base
{
    public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class, IEntityBase
        where TContext : DbContext
    {
        private readonly TContext _context;
        public BaseRepository(TContext context)
        {
            this._context = context;
        }
        async Task<TEntity> IBaseRepository<TEntity>.Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        async Task<TEntity> IBaseRepository<TEntity>.Delete(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        async Task<TEntity> IBaseRepository<TEntity>.GetById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        async Task<ICollection<TEntity>> IBaseRepository<TEntity>.GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        async Task<ICollection<TEntity>> IBaseRepository<TEntity>.GetAllAsNoTracking()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        async Task<TEntity> IBaseRepository<TEntity>.Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        void IDisposable.Dispose()
        {
            this._context.Dispose();
        }
    }
}
