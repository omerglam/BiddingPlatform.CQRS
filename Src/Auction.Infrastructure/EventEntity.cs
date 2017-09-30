using System;

namespace Auction.Infrastructure
{
    public class EventEntity
    {
        public Guid Id { get; private set; }

        public DateTime Timestamp { get; private set; }

        public string Payload { get; private set; }

        public EventEntity(Guid id, DateTime timestamp, string payload)
        {
            Id = id;
            Timestamp = timestamp;
            Payload = payload;
        }
    }
}