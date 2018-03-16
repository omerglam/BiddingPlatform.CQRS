using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace Infrastructure.Persistence.EF
{
    public interface IRepository<T>  where T  : class
    {

        Task<T> Get(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        Task<T[]> GetCollection(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        Task Add(T entity);

        Task Modify(T entity);

        Task Remove(T entity);
    }
}