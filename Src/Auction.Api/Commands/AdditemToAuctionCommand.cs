using System;
using Auction.Domain;
using MediatR;

namespace Auction.API.Commands
{
    public class AdditemToAuctionCommand : IRequest
    {
        public AdditemToAuctionCommand(AuctionItem item, Guid auctionId)
        {
            Item = item;
            AuctionId = auctionId;
        }

        public Guid AuctionId { get; set; }
        public Domain.AuctionItem Item { get; }
    }
}