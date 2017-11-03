using System;
using System.Threading.Tasks;

namespace Infrastructure.DDD
{
    public interface IAggregateRepository<T> where T : IAggregateRoot
    {

        Task Add(T aggregate);

        Task Update(T aggregate);

        Task<T> Find(Guid id);
    }
}