using System;
using System.Threading.Tasks;
using Infrastructure.DDD;
using MediatR;

namespace Auction.API.Commands.Handlers
{
    public class AuctionCommandHandler : IAsyncRequestHandler<AddBidCommand>, IAsyncRequestHandler<CreateAuctionCommand>
    {
        private readonly IAggregateRepository<Domain.Auction> _auctionRepository;

        public AuctionCommandHandler(IAggregateRepository<Domain.Auction> auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        public async Task Handle(AddBidCommand command) //TODO:  move to other command handler (Bid command handler?)
        {
            var auction = await _auctionRepository.Find(command.Id);

            if (auction is null) // Todo: in case of asynchornous command handling - should this validation be moved to the command initiator (i.e. API)?
            {
                throw new InvalidOperationException($"auction id: {command.Id} not found");
            }

            auction.AddBid(command.ItemId, command.Bidder, command.Amount, command.BidTimestamp);

            await _auctionRepository.Update(auction);
      
        }

        public async Task Handle(CreateAuctionCommand message)
        {
            // Validation? how to validate busniess requirement of a unique auction name ?

            var auction = new Domain.Auction(new Guid(), message.Name, message.Items);

            await _auctionRepository.Add(auction);
        }
    }
}
