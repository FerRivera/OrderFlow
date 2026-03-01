using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Orders.Domain.Outbox
{
    public class OutboxMessage
    {
        public Guid Id { get; set; }
        public DateTime OccurredOnUtc { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Payload { get; set; } = string.Empty;
        public DateTime? ProcessedOnUtc { get; set; }
        public string? Error { get; set; }

        public static OutboxMessage Create(string type, string payload)
        {
            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentException("Type is required.", nameof(type));

            if (string.IsNullOrWhiteSpace(payload))
                throw new ArgumentException("Payload is required.", nameof(payload));

            return new OutboxMessage
            {
                Id = Guid.NewGuid(),
                OccurredOnUtc = DateTime.UtcNow,
                Type = type,
                Payload = payload,
                ProcessedOnUtc = null,
                Error = null
            };
        }
    }
}
