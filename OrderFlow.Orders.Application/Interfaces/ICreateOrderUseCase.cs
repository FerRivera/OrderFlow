using OrderFlow.Orders.Application.DTO;
using OrderFlow.Orders.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Orders.Application.Interfaces
{
    public interface ICreateOrderUseCase
    {
        Task<Order> ExecuteAsync(CreateOrderRequest request, CancellationToken ct = default);
    }
}
