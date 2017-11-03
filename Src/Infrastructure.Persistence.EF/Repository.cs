using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EF
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate, params CascadedIncludes<T, object, object>[] includes)
        {
            var dbSet = _context.Set<T>();

            if (includes != null)
            {
                foreach (var cascadedIncludese in includes)
                {
                    dbSet.Include(cascadedIncludese.MainInclude).ThenInclude(cascadedIncludese.SecondaryInclude);
                }
            }

            return await InnerGet(dbSet, predicate);
        }


        public async Task<T> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var dbSet = _context.Set<T>();

            if (includes != null)
            {
                foreach (var expression in includes)
                {
                    dbSet.Include(expression);
                }
            }
            return await InnerGet(dbSet, predicate);
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