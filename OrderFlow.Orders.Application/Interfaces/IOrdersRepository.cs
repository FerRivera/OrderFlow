using OrderFlow.Orders.Domain.Orders;
using OrderFlow.Orders.Domain.Outbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Orders.Application.Interfaces
{
    public interface IOrdersRepository
    {
        Task AddAsync(Order order, CancellationToken ct = default);
        Task<Order?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task AddWithOutboxAsync(Order order, OutboxMessage message, CancellationToken ct = default);
    }
}
