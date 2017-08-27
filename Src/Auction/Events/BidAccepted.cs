using System;
using Infrastructure;
using MediatR;

namespace Auction.Events
{
    public class BidAccepted : INotification
    {
        public BidAccepted(Guid sourceId, int itemId, string bidder, decimal amount, DateTime bidTimestamp)
        {
            SourceId = sourceId;
            ItemId = itemId;
            Bidder = bidder;
            Amount = amount;
            BidTimestamp = bidTimestamp;
        }

        public Guid SourceId { get; private set; }

        public int ItemId { get; private set; }

        public string Bidder { get; private set; }

        public decimal Amount { get; private set; }

        public DateTime BidTimestamp { get; private set; }

    }
}