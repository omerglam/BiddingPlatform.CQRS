using System;

namespace Auction.Infrastructure.EntitiesConfigurations
{
    internal class IntegrationEventEntity
    {
        public Guid Id { get; private set; }

        public DateTime Timestamp { get; private set; }

        public string Payload { get; private set; }

        public IntegrationEventEntity(Guid id, DateTime timestamp, string payload)
        {
            Id = id;
            Timestamp = timestamp;
            Payload = payload;
        }
    }
}