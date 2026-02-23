using OrderFlow.Orders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Orders.Application.DTO
{
    public sealed record CreateOrderRequest(Guid UserId, Operation Operation, decimal Amount);
}
