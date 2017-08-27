using System;
using Infrastructure;

namespace Auction.API.Commands
{
    public class AddBidCommand : ICommand
    { 
        public Guid Id { get;}

        public string Bidder { get;  }

        public decimal  Amount { get;  }

        public Guid AuctionId { get; }

        public int ItemId { get; }

        public AddBidCommand(string bidder, Guid auctionId, int itemId, decimal amount)
        {
            this.Id = Guid.NewGuid();
            Bidder = bidder;
            AuctionId = auctionId;
            ItemId = itemId;
            Amount = amount;
        }
    }
}
