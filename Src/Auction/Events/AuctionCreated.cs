using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;

namespace Auction.Events
{
    public class AuctionCreated : IEvent
    {
        public Guid SourceId { get; private set; }

        public string[] Items { get; private set; }

        public AuctionCreated(Guid sourceId, string[] items)
        {
            SourceId = sourceId;
            Items = items;
        }
    }

    public class BidRejected : IEvent
    {
        public BidRejected(Guid sourceId, string reason)
        {
            SourceId = sourceId;
            Reason = reason;
        }

        public Guid SourceId { get; private set; }

        public string Reason { get; private set; }
    }
}
