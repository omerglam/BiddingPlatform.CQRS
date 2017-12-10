using Auction.API.Controllers.Model;
using MediatR;
using AuctionItem = Auction.Domain.AuctionItem;

namespace Auction.API.Commands
{
    public class CreateAuctionCommand : IRequest
    {
        public CreateAuctionCommand(string name, AuctionItem[] items)
        {
            Name = name;
            Items = items;
        }

        public string Name { get; }

        public Domain.AuctionItem[] Items { get; }
    }
}