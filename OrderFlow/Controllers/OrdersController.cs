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
        private readonly ICreateOrderUseCase _createOrderUseCase;
        public OrdersController(ICreateOrderUseCase createOrderUseCase) 
        {
            _createOrderUseCase = createOrderUseCase;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateOrderHttpRequest request)
        {
            var userId = Guid.Parse("11111111-1111-1111-1111-111111111111");

            var appRequest = new CreateOrderRequest(
                userId,
                request.Operation,
                request.Amount);

            var order = _createOrderUseCase.Execute(appRequest);
            //return Ok(order);
            return Created("", order);
        }
    }
}
