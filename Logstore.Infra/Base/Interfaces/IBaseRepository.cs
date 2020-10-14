using Logstore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logstore.Infra.Base.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class, IEntityBase
    {
        Task<ICollection<TEntity>> GetAll();
        Task<ICollection<TEntity>> GetAllAsNoTracking();
        Task<TEntity> GetById(int id);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(int id);
    }
}
