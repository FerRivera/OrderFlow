using OrderFlow.Orders.Application.DTO;
using OrderFlow.Orders.Application.Interfaces;
using OrderFlow.Orders.Domain;
using OrderFlow.Orders.Domain.Orders;
using OrderFlow.Orders.Domain.Outbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderFlow.Orders.Application.UseCases
{
    public sealed class CreateOrder : ICreateOrder
    {
        private readonly IOrdersRepository _ordersRepository;
        public CreateOrder(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }
        public async Task<Order> ExecuteAsync(CreateOrderRequest request, CancellationToken ct)
        {

            var order = Order.Create(request.UserId, request.Operation, request.Amount);

            var payload = JsonSerializer.Serialize(new
            {
                order.Id,
                order.UserId,
                order.Operation,
                order.Amount,
                order.Status,
                order.CreatedAtUtc
            });

            var outBoxMessage = OutboxMessage.Create("OrderCreated",payload);

            await _ordersRepository.AddWithOutboxAsync(order, outBoxMessage, ct);
            return order;

        }
    }
}
