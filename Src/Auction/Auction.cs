﻿using System;
using System.Collections.Generic;
using System.Linq;
using Auction.Domain.Events;
using Auction.Events;
using Infrastructure;
using Infrastructure.DDD;
using MediatR;

namespace Auction.Domain
{
    public class Auction : IAggregateRoot, IEventPublisher
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        private List<INotification> _events = new List<INotification>();

        public IEnumerable<INotification> Events  => _events;

        public ICollection<AuctionItem> Items { get; private set; }

        protected Auction() {}

        public Auction(Guid id, string name, AuctionItem[] items)
        {
            Id = id;
            Items = new List<AuctionItem>();
            Name = name;

            foreach (var auctionItem in items)
            {
                AddItemToAuction(auctionItem.Name,auctionItem.Description,auctionItem.ReservedPrice);
            }

            _events.Add(new AuctionCreated(this.Id, this.Name, items.Select(i => i.Name).ToArray()));
        }

        public void AddBid(int itemId, string bidder, decimal amount, DateTime bidTimestamp)
        {
            var item = Items.SingleOrDefault(i => i.Id == itemId);

            if (item == null)
            {
                throw new InvalidOperationException($"item with id : {itemId} doesn't exists");
            }

            var highestBid = item.Bids.Max(i => i.Amount); //TODO: should this domain logic be in the entity? if so - how to propogate the domain event? from he AggregateRoot or entity?

            if (amount <= highestBid)
            {
                _events.Add(new BidRejected(this.Id,itemId, bidder,amount, "Bid is less than the highest bid", bidTimestamp));
            }

            item.AddBid(new Bid(bidder, amount, bidTimestamp));

            _events.Add(new BidAccepted(this.Id, itemId, bidder, amount, bidTimestamp));

        }

        public void AddItem(string newItemName, string description, decimal? reservedPrice)
        {
            AddItemToAuction(newItemName, description, reservedPrice);

            //TODO: add domain event "Auction item added" ?
        }

        private void AddItemToAuction(string newItemName, string description, decimal? reservedPrice)
        {

            if (Items.Any(item => item.Name == newItemName))
            {
                throw new InvalidOperationException("Item name already exists");
            }

            var newItemId = Items.Count;

            Items.Add(new AuctionItem(newItemId, newItemName, description, reservedPrice));

        }
    }
}
