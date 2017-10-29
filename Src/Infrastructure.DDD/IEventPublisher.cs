using System.Collections.Generic;
using MediatR;

namespace Infrastructure.DDD
{
    public interface IEventPublisher
    {
        IEnumerable<INotification> Events { get; }
    }
}