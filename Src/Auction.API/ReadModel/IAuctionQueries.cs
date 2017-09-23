using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.API.ReadModel.Model;

namespace Auction.API.ReadModel
{
    interface IAuctionQueries
    {
        AuctionStatusReadModel GetAuctionStatus(Guid auctionId);
    }
}
