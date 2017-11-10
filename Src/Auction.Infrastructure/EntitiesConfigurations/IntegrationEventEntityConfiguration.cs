using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction.Infrastructure.EntitiesConfigurations
{
    internal class IntegrationEventEntityConfiguration : IEntityTypeConfiguration<IntegrationEventEntity>
    {
        public void Configure(EntityTypeBuilder<IntegrationEventEntity> builder)
        {
            builder.ToTable("Integration_events_queue");
            builder.Property(e => e.Payload).HasMaxLength(int.MaxValue);
        }
    }
}