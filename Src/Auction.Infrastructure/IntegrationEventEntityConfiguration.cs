using System.Data.Entity.ModelConfiguration;

namespace Auction.Infrastructure
{
    public class IntegrationEventEntityConfiguration : EntityTypeConfiguration<EventEntity>
    {
        public IntegrationEventEntityConfiguration()
        {
            ToTable("integration_events_queue");
            Property(e => e.Payload).HasMaxLength(int.MaxValue);
        }

    }
}