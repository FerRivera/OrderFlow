using Microsoft.AspNetCore.Mvc;
using OrderFlow.Orders.Application.DTO;
using OrderFlow.Orders.Application.Interfaces;
using OrderFlow.Orders.Domain;

namespace OrderFlow.Orders.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly ICreateOrderUseCase _createOrderUseCase;
        public HealthController(ICreateOrderUseCase createOrderUseCase)
        {
            _createOrderUseCase = createOrderUseCase;
        }

        [HttpGet("domain")]
        public IActionResult Get()
        {
            CreateOrderRequest createOrderRequest = new CreateOrderRequest
            (
                Guid.NewGuid(),
                Operation.Buy,
                10m
            );

            var response = _createOrderUseCase.ExecuteAsync(createOrderRequest);
            return Ok(response);
        }
    }
}
