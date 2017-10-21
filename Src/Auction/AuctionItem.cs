using System.Collections.Generic;

namespace Auction.Domain
{
    public class AuctionItem
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal? ReservedPrice { get; private set; }

        public ICollection<Bid> Bids { get; private set; }

        public AuctionItem(int id, string name, string description, decimal? reservedPrice)
        {
            Id = id;
            Name = name;
            Description = description;
            ReservedPrice = reservedPrice;
            Bids = new List<Bid>();
        }

        public void AddBid(Bid bid)
        {
            Bids.Add(bid);
        }
    }
}