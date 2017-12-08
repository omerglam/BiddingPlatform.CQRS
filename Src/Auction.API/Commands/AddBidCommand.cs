using System;
using MediatR;

namespace Auction.API.Commands
{
    public class AddBidCommand : IRequest
    { 
        public Guid Id { get;}

        public string Bidder { get;  }

        public decimal  Amount { get;  }

        public Guid AuctionId { get; }

        public int ItemId { get; }

        public DateTime BidTimestamp { get; }

        public AddBidCommand(string bidder, Guid auctionId, int itemId, decimal amount, DateTime bidTimestamp)
        {
            this.Id = Guid.NewGuid();
            Bidder = bidder;
            AuctionId = auctionId;
            ItemId = itemId;
            Amount = amount;
            BidTimestamp = bidTimestamp;
        }
    }
}
