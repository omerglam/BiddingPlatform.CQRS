using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IAggregateRoot
    {
         Guid Id { get; }
    }

    public interface IAggregateRepository<T> where T : IAggregateRoot
    {
        Task Save(T aggregate);

        Task<T> Find(Guid id);
    }

    public interface IEventPublisher
    {
        IEnumerable<IEvent> Events { get; }
    }

    public interface IEvent
    {
        Guid SourceId { get; }
    }
}

