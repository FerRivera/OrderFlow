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
        public async Task<IActionResult> Create([FromBody] CreateOrderHttpRequest request, [FromHeader(Name = "X-User-Id")] string? userIdHeader, CancellationToken ct)
        {
            try
            {
                if (!Guid.TryParse(userIdHeader, out Guid userId)) return BadRequest("Missing/Invalid X-User-Id");

                var appRequest = new CreateOrderRequest(
                    userId,
                    request.Operation,
                    request.Amount);

                var order = await _createOrder.ExecuteAsync(appRequest, ct);
                return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id, [FromHeader(Name = "X-User-Id")] string? userIdHeader, CancellationToken ct)
        {
            if (!Guid.TryParse(userIdHeader, out Guid userId)) return BadRequest("Missing/Invalid X-User-Id");

            var order = await _getOrderById.ExecuteAsync(id, ct);

            if(order is null) return NotFound();

            if (order.UserId != userId) return NotFound();

            return Ok(order);
        }
    }
}
