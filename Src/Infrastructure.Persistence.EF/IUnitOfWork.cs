using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.EF
{
    public interface IUnitOfWork
    {
        Task SaveChanges();

        IRepository<T> GetRepository<T>() where T : class;
    }

    public interface IRepository<T>  where T  : class //Todo: change to Entity
    {
        T Get(Expression<Func<T,bool>> predicate);

        Task Save(T entity);
    }

    abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public T Get(Expression<Func<T, bool>> predicate /*includes*/)
        {
            throw new NotImplementedException();
        }

        public Task Save(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }



            throw new NotImplementedException();
        }

        protected abstract T GetInternal(Expression<Func<T, bool>> predicate);
        protected abstract T SaveInternal(T entity);
    }
}
