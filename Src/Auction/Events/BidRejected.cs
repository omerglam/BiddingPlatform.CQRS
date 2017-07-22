using System;
using Infrastructure;

namespace Auction.Events
{
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
}