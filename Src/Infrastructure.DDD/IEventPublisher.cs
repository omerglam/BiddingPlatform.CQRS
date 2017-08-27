using System.Collections.Generic;
using Infrastructure;
using MediatR;

namespace Common.Infrastructure
{
    public interface IEventPublisher
    {
        IEnumerable<INotification> Events { get; }
    }
}