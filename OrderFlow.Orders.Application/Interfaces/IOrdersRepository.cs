using OrderFlow.Orders.Domain.Orders;
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
    }
}
