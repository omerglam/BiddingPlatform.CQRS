using System.Data.Entity.ModelConfiguration;

namespace Auction.Infrastructure
{
    internal class IntegrationEventEntityConfiguration : EntityTypeConfiguration<IntegrationEventEntity>
    {
        public IntegrationEventEntityConfiguration()
        {
            ToTable("integration_events_queue");
            Property(e => e.Payload).HasMaxLength(int.MaxValue);
        }

    }
}