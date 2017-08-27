using System.Collections.Generic;

namespace Auction.Domain
{
    public class AuctionItem
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal? ReservedPrice { get; private set; }

        private List<Bid> _bids;

        public IEnumerable<Bid> Bids { get; private set; }

        public void AddBid(Bid bid)
        {
            _bids.Add(bid);
        }
    }
}