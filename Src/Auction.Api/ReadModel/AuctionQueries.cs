using System;
using System.Linq;
using System.Threading.Tasks;
using Auction.Api.ReadModel.Model;
using Auction.API.ReadModel.Model;
using Infrastructure.Persistence.EF;

namespace Auction.API.ReadModel
{
    public class AuctionQueries : IAuctionQueries
    {
        private readonly IRepository<Domain.Auction> _auctionRepository;

        public AuctionQueries(IRepository<Domain.Auction> auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        public Task<AuctionStatusReadModel> GetAuctionStatus(Guid auctionId)
        {
            throw new NotImplementedException();
        }

        public async  Task<AuctionHighLevelView[]> GetAuctionsHighLevelView()
        {
            var highlevelview = await _auctionRepository.GetCollection();

            return highlevelview.Select(i => new AuctionHighLevelView() {Id = i.Id, Name = i.Name}).ToArray();
        }
    }
}