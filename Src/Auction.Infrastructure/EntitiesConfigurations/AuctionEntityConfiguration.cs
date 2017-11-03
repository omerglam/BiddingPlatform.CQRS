using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction.Infrastructure.EntitiesConfigurations
{
    public class AuctionEntityConfiguration : IEntityTypeConfiguration<Domain.Auction>
    {

        public void Configure(EntityTypeBuilder<Domain.Auction> builder)
        {
            builder.ToTable("Auction");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Name).HasColumnName("Name");

            //builder.Ignore(e => e.Events);

            builder.HasMany(a => a.Items);
        }

    }

    
}