using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using MediatR;

namespace Auction.Events
{
    public class AuctionCreated : INotification
    {
        public Guid SourceId { get; private set; }

        public string[] Items { get; private set; }

        public AuctionCreated(Guid sourceId, string[] items)
        {
            SourceId = sourceId;
            Items = items;
        }
    }
}
