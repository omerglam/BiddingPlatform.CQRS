using System;

namespace Auction.Domain
{
    public class Bid
    {
        public Bid(string bidder, decimal amount, DateTime bidTimestamp)
        {
            Bidder = bidder;
            Amount = amount;
            BidTimestamp = bidTimestamp;
        }

        public string Bidder { get; private set; }

        public decimal Amount { get; private set; }

        public DateTime BidTimestamp { get; private set; }

    }
}