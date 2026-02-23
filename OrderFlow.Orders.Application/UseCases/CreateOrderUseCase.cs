using OrderFlow.Orders.Application.DTO;
using OrderFlow.Orders.Application.Interfaces;
using OrderFlow.Orders.Domain;
using OrderFlow.Orders.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Orders.Application.UseCases
{
    public sealed class CreateOrderUseCase : ICreateOrderUseCase
    {
        public Order Execute(CreateOrderRequest request)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Operation = request.Operation,
                Amount = request.Amount,
                Status = OrderStatus.PendingPayment,
                CreatedAtUtc = DateTime.UtcNow,
                UpdatedAtUtc = null
            };
            return order;
        }
    }
}
