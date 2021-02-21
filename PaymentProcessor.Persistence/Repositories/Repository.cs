using Microsoft.EntityFrameworkCore;
using PaymentProcessor.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.Persistence.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal DbContext _context;
        //internal DbSet<TEntity> Entity;
        public int ChangeCount;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public async Task Add(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task<bool> SaveAsync()
        {
            ChangeCount = await _context.SaveChangesAsync();
            return ChangeCount > 0;
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter = null)
        {
            return _context.Set<TEntity>().FirstOrDefault(filter);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().FirstOrDefault(filter);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<IQueryable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            return await Task.FromResult(_context.Set<TEntity>().Where(filter).AsQueryable<TEntity>());
        }

        public TEntity LastOrDefault(Expression<Func<TEntity, bool>> filter = null)
        {
          return  _context.Set<TEntity>().LastOrDefault(filter);
        }


        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

    }
}
