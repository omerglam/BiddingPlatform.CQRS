using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Api.ReadModel.Model;
using Auction.API.ReadModel.Model;
using Auction.Infrastructure;

namespace Auction.API.ReadModel
{
    public interface IAuctionQueries
    {
        Task<AuctionStatusReadModel> GetAuctionStatus(Guid auctionId);

        Task<AuctionHighLevelView[]> GetAuctionsHighLevelView();
    }
}
