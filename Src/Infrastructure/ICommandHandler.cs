﻿using System.Threading.Tasks;

namespace Infrastructure
{
    public interface ICommandHandler { }

    public interface ICommandHandler<T> : ICommandHandler
        where T : ICommand
    {
        Task Handle(T command);
    }
}