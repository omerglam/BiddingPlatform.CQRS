namespace Auction
{
    public class Bid
    {
        public Bid(string bidder, decimal amount)
        {
            Bidder = bidder;
            Amount = amount;
        }

        public string Bidder { get; private set; }

        public decimal Amount { get; private set; }

    }
}