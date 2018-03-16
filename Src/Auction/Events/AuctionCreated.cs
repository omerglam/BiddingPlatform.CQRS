using System;
using MediatR;

namespace Auction.Domain.Events
{
    public class AuctionCreated : INotification
    {
        public Guid SourceId { get; private set; }

        public string Name { get; private set; }

        public string[] Items { get; private set; }

        public AuctionCreated(Guid sourceId, string name, string[] items)
        {
            SourceId = sourceId;
            Items = items;
            Name = name;
        }
    }
}
