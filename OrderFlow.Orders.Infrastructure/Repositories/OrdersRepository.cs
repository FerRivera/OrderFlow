using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderFlow.Orders.Application.Interfaces;
using OrderFlow.Orders.Domain.Orders;
using OrderFlow.Orders.Infrastructure.Persistence;

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
    }
}
