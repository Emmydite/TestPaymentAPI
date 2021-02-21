using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.Persistence.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Add(TEntity entity);
        Task<bool> SaveAsync();
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter = null);
        TEntity LastOrDefault(Expression<Func<TEntity, bool>> filter = null);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IQueryable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter);
    }
}
