using OrderFlow.Orders.Application.Interfaces;
using OrderFlow.Orders.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Orders.Application.UseCases
{
    public sealed class GetOrderById : IGetOrderById
    {
        private readonly IOrdersRepository _ordersRepository;
        public GetOrderById(IOrdersRepository ordersRepository) 
        { 
            _ordersRepository = ordersRepository;
        }
        public async Task<Order?> ExecuteAsync(Guid id, CancellationToken ct = default)
        {
            return await _ordersRepository.GetByIdAsync(id, ct);
        }
    }
}
