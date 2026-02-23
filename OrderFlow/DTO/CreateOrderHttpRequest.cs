using OrderFlow.Orders.Domain;

namespace OrderFlow.Orders.Api.DTO
{
    public sealed record CreateOrderHttpRequest(Operation Operation, decimal Amount);
}
