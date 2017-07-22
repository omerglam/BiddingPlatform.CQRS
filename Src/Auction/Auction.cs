using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Events;
using Infrastructure;

namespace Auction
{
    public class Auction : IAggregateRoot, IEventPublisher
    {
        public Guid Id { get; private set; }

        private List<IEvent> _events = new List<IEvent>();
        public IEnumerable<IEvent> Events  => _events; 

        public AuctionItem[] Items { get; private set; }

        public Auction(Guid id, AuctionItem[] items)
        {
            Id = id;
            Items = items;

            _events.Add(new AuctionCreated(this.Id, items.Select(i => i.Name).ToArray()));
        }

        public void Bid(int itemId, Bid newBid)
        {
            var item = Items.SingleOrDefault(i => i.Id == itemId);

            if (item == null)
            {
                throw new InvalidOperationException($"item with id : {itemId} couldn't be found");
            }

            var highestBid = item.Bids.Max(i => i.Amount);

            if (newBid.Amount <= highestBid)
            {
                _events.Add(new BidRejected(this.Id,itemId,newBid.Bidder,newBid.Amount, "Bid is less than the highest bid"));
            }

            item.AddBid(newBid);

            _events.Add(new BidAccepted(this.Id, itemId, newBid.Bidder, newBid.Amount));

        }
    }
}
