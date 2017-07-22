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
        public BidRejected(Guid sourceId, int itemId, string bidder, decimal amount, string reason)
        {
            SourceId = sourceId;
            ItemId = itemId;
            Reason = reason;
            Bidder = bidder;
            Amount = amount;
        }

        public Guid SourceId { get; private set; }

        public int ItemId { get; private set; }

        public string Bidder { get; private set; }

        public decimal Amount { get; private set; }

        public string Reason { get; private set; }
    }

    public class BidAccepted : IEvent
    {
        public Guid SourceId { get; private set; }

        public int ItemId { get; private set; }

        public string Bidder { get; private set; }

        public decimal Amount { get; private set; }
    }
}
