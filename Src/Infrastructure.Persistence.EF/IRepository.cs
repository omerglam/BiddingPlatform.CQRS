using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.EF
{
    public interface IRepository<T>  where T  : class
    {
        Task<T> Get(Expression<Func<T,bool>> predicate, params Expression<Func<T,object>>[] includes);

        void AddOrUpdate(T entity);
    }
}