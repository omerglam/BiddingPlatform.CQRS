namespace Auction.API.Controllers.Model
{
    public class CreateAuctionRequest
    {
        public string Name { get; set; }

        public AuctionItem[] AuctionItems { get; set; }
    }
}