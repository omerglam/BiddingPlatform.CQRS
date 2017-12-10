namespace Auction.API.Controllers.Model
{
    public class AuctionItem
    {
        public string Name { get; set; }

        public decimal? ReservedPrice { get; set; }

        public string Description { get; set; }
    }
}