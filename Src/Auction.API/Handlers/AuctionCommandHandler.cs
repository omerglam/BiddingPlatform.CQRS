using System;
using System.Threading.Tasks;
using Auction.API.Commands;
using Infrastructure;

namespace Auction.API.Handlers
{
    public class AuctionCommandHandler : ICommandHandler<AddBidCommand>
    {
        private IAggregateRepository<Auction> _auctionRepository;

        public AuctionCommandHandler(IAggregateRepository<Auction> auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        public async Task Handle(AddBidCommand command)
        {
            //TODO: where does the validation that the auction exists? API before issueing the command

            var auction = await _auctionRepository.Find(command.Id);

            auction.Bid(command.ItemId, new Bid(command.Bidder, command.Amount));

            await _auctionRepository.Save(auction);
      
            throw new NotImplementedException();
        }
    }
}
