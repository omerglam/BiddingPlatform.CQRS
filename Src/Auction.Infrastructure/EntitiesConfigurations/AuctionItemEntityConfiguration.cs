using System;
using Auction.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction.Infrastructure.EntitiesConfigurations
{
    public class AuctionItemEntityConfiguration : IEntityTypeConfiguration<Domain.AuctionItem>
    {
     
        public void Configure(EntityTypeBuilder<AuctionItem> builder)
        {
            builder.ToTable("Auction_Items");

            builder.Property<Guid>("UniqueId").ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");

            builder.HasKey("UniqueId");

            builder.HasAlternateKey("Id", "AuctionId").HasName("AlternateKey_itemId_auctionId"); // Id is scoped and unique per auction id 

            

        }
    }
}