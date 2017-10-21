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
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T,object>>[] includes)
        {
            var predicateInner = predicate ?? throw new ArgumentNullException(nameof(predicate));

            if (includes != null)
            {
                foreach (var expression in includes)
                {
                    _dbSet.Include(expression);
                }
            }

            var query = _dbSet.Where(predicateInner);

            var entity = await query.FirstOrDefaultAsync();

            return entity;
        }

        public async Task Add(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            await _dbSet.AddAsync(entity);
        }

        public async Task Modify(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Update(entity);
        }

        public async Task Remove(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }
    }
}