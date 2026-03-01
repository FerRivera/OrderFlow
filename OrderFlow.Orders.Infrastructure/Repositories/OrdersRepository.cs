using Microsoft.EntityFrameworkCore;
using OrderFlow.Orders.Application.Interfaces;
using OrderFlow.Orders.Domain.Orders;
using OrderFlow.Orders.Domain.Outbox;
using OrderFlow.Orders.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Orders.Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly OrdersDbContext _db;
        public OrdersRepository(OrdersDbContext db)
        {
            _db = db;
        }
        public async Task AddAsync(Order order, CancellationToken ct = default)
        {
            await _db.Orders.AddAsync(order,ct);
            await _db.SaveChangesAsync(ct);
        }

        public async Task<Order?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _db.Orders.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id,ct);
        }

        public async Task AddWithOutboxAsync(Order order, OutboxMessage message, CancellationToken ct = default)
        {
            await _db.Orders.AddAsync(order, ct);
            await _db.OutboxMessages.AddAsync(message, ct);
            await _db.SaveChangesAsync(ct);
        }
    }
}
