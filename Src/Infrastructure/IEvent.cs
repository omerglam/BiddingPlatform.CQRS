using System;

namespace Infrastructure
{
    public interface IEvent
    {
        Guid SourceId { get; }
    }
}