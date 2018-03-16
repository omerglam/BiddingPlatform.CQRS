using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Infrastructure.Persistence.EF
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }



        public async Task<T> Get(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            var predicateInner = predicate ?? throw new ArgumentNullException(nameof(predicate));

            var query = (IQueryable<T>)_context.Set<T>();

            if (include != null)
            {
                query = include(query);
            }

             query = query.Where(predicateInner);

            var entity = await query.FirstOrDefaultAsync();

            return entity;

        }

        public async Task<T[]> GetCollection(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            var query = (IQueryable<T>)_context.Set<T>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (include != null)
            {
                query = include(query);
            }

            return await query.ToArrayAsync();
        }

        public async Task Add(T entity)
        {
            var dbSet = _context.Set<T>();

            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            await dbSet.AddAsync(entity);
        }

        public async Task Modify(T entity)
        {
            var dbSet = _context.Set<T>();

            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            dbSet.Update(entity);
        }

        public async Task Remove(T entity)
        {
            var dbSet = _context.Set<T>();

            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            dbSet.Remove(entity);
        }

        private async Task<T> InnerGet(DbSet<T> dbSet, Expression<Func<T, bool>> predicate)
        {
            var predicateInner = predicate ?? throw new ArgumentNullException(nameof(predicate));

            var query = dbSet.Where(predicateInner);

            var entity = await query.FirstOrDefaultAsync();

            return entity;
        }
    }
}