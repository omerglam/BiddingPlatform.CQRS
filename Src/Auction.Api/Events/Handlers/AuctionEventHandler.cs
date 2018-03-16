using System;
using System.Threading.Tasks;
using Auction.Domain.Events;
using MediatR;

namespace Auction.API.Events.Handlers
{
    public class AuctionEventHandler : IAsyncNotificationHandler<AuctionCreated>
    {
        public Task Handle(AuctionCreated notification)
        {
            return Task.CompletedTask;
        }
    }
}