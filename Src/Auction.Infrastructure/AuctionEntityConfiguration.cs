using Auction.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction.Infrastructure
{
    public class AuctionEntityConfiguration : IEntityTypeConfiguration<Domain.Auction>
    {
        public AuctionEntityConfiguration()
        {
            

        }

        public void Configure(EntityTypeBuilder<Domain.Auction> builder)
        {
            builder.ToTable("auction");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Name).HasColumnName("Name");

            //Ignore(e => e.Events);

            builder.HasMany(a => a.Items);
        }
    }

    public class AuctionItemEntityConfiguration : IEntityTypeConfiguration<Domain.AuctionItem>
    {
        public AuctionItemEntityConfiguration()
        {
            
        }

        public void Configure(EntityTypeBuilder<AuctionItem> builder)
        {
            builder.ToTable("Auction_Items");
        }
    }

    public class BidEntityConfiguration : IEntityTypeConfiguration<Domain.Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> builder)
        {
            
        }
    }

}