using System;

namespace Infrastructure
{
    public interface ICommand
    {
        Guid Id { get; }
    }
}