using System;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IAggregateRepository<T> where T : IAggregateRoot
    {
        Task Save(T aggregate); //Todo: publish aggregate events and only then commit all changes togther - integration events should be published only when the save to db completed succefuly

        Task<T> Find(Guid id);
    }
}