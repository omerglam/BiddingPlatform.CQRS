using System;
using System.Threading.Tasks;
using Infrastructure.DDD;
using MediatR;

namespace Auction.API.Commands.Handlers
{
    public class AuctionCommandHandler : IAsyncRequestHandler<CreateAuctionCommand>, IAsyncRequestHandler<AdditemToAuctionCommand>
    {
        private readonly IAggregateRepository<Domain.Auction> _auctionRepository;

        public AuctionCommandHandler(IAggregateRepository<Domain.Auction> auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }
      

        public async Task Handle(CreateAuctionCommand message)
        {
            // Validation? how to validate busniess requirement of a unique auction name ?

            var auction = new Domain.Auction(new Guid(), message.Name, message.Items);

            await _auctionRepository.Add(auction);
        }

        public async Task Handle(AdditemToAuctionCommand message)
        {
            var auction = await _auctionRepository.Find(message.AuctionId);

            auction.AddItem(message.Item.Name, message.Item.Description, message.Item.ReservedPrice);
        }
    }
}
