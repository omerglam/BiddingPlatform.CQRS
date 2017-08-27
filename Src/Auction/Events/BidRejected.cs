using System;
using Infrastructure;
using MediatR;

namespace Auction.Events
{
    public class BidRejected : INotification
    {
        public BidRejected(Guid sourceId, int itemId, string bidder, decimal amount, string reason, DateTime bidTimestamp)
        {
            SourceId = sourceId;
            ItemId = itemId;
            Reason = reason;
            BidTimestamp = bidTimestamp;
            Bidder = bidder;
            Amount = amount;
        }

        public Guid SourceId { get; private set; }

        public int ItemId { get; private set; }

        public string Bidder { get; private set; }

        public decimal Amount { get; private set; }

        public string Reason { get; private set; }

        public DateTime BidTimestamp { get; private set; }
    }
}