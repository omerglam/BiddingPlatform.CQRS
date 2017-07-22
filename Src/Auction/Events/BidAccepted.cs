using System;
using Infrastructure;

namespace Auction.Events
{
    public class BidAccepted : IEvent
    {
        public BidAccepted(Guid sourceId, int itemId, string bidder, decimal amount)
        {
            SourceId = sourceId;
            ItemId = itemId;
            Bidder = bidder;
            Amount = amount;
        }

        public Guid SourceId { get; private set; }

        public int ItemId { get; private set; }

        public string Bidder { get; private set; }

        public decimal Amount { get; private set; }
    }
}