﻿using System;

namespace Auction.API.Events.IntegrationEvents
{
    public class BidAddedIntegrationEvent //Todo : marker interface for integration events?
    {
        public BidAddedIntegrationEvent(Guid auctionId, int itemId, string bidder, decimal bidAmount)
        {
            AuctionId = auctionId;
            ItemId = itemId;
            Bidder = bidder;
            BidAmount = bidAmount;
        }

        public Guid AuctionId { get; }

        public int ItemId { get; }

        public string Bidder { get; }

        public decimal BidAmount { get;  }
    }
}
