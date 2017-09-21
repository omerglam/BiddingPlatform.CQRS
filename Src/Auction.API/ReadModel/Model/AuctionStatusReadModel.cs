using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.API.ReadModel.Model
{
    public class AuctionStatusReadModel
    {
        public Guid AuctionId { get;  set; }

        public AuctionItemReadModel[] AuctionItems { get; set; }
    }

    public class AuctionItemReadModel
    {
        public enum Status
        {
            PendingAuction,
            ReservedNotMet,
            Sold
        }

        public int Id { get; set; }
        


    }
}
