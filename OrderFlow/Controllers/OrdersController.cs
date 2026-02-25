using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderFlow.Orders.Api.DTO;
using OrderFlow.Orders.Application.DTO;
using OrderFlow.Orders.Application.Interfaces;

namespace OrderFlow.Orders.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ICreateOrder _createOrder;
        private readonly IGetOrderById _getOrderById;
        public OrdersController(ICreateOrder createOrderUseCase, IGetOrderById getOrderById) 
        {
            _createOrder = createOrderUseCase;
            _getOrderById = getOrderById;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderHttpRequest request, CancellationToken ct)
        {
            var userId = Guid.Parse("11111111-1111-1111-1111-111111111111");

            var appRequest = new CreateOrderRequest(
                userId,
                request.Operation,
                request.Amount);

            var order = await _createOrder.ExecuteAsync(appRequest,ct);
            return CreatedAtAction(nameof(Get), new {id = order.Id}, order);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        {
            var order = await _getOrderById.ExecuteAsync(id, ct);

            if(order is null) return NotFound();

            return Ok(order);
        }
    }
}
