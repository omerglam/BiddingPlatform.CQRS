using System.Data.Entity.ModelConfiguration;

namespace Auction.Infrastructure
{
    public class AuctionEntityConfiguration : EntityTypeConfiguration<Domain.Auction>
    {
        public AuctionEntityConfiguration()
        {
            ToTable("auction");

            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("Id");
            Property(e => e.Name).HasColumnName("Name");

            //Ignore(e => e.Events);

            HasMany(a => a.Items);

        }
    }
}