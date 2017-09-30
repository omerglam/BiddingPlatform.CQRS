using System;

namespace Infrastructure.DDD
{
    public interface IAggregateRoot
    {
         Guid Id { get; }
    }
}

