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
            //builder.HasKey(e => e.Id); //TODO: auto-generated per auction id?

            // TODO: shadow property to the auction id
        }
    }
}