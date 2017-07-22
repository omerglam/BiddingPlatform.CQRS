using System;
using System.Linq;
using System.Text;

namespace Infrastructure
{
    public interface IAggregateRoot
    {
         Guid Id { get; }
    }
}

