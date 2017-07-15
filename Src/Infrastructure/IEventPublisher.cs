using System.Collections.Generic;

namespace Infrastructure
{
    public interface IEventPublisher
    {
        IEnumerable<IEvent> Events { get; }
    }
}