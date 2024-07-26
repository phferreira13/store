using MediatR;
using Microsoft.AspNetCore.Mvc;
using order.service.business.UseCases.Orders;
using order.service.domain.Models;

namespace order.service.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("{orderId}")]
        [ProducesResponseType(typeof(Order), 200)]
        public async Task<IActionResult> GetOrder([FromRoute] Guid orderId)
        {
            var order = await _mediator.Send(new GetOrderQuery(orderId));
            if (order is null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Order), 201)]
        public async Task<IActionResult> AddOrder([FromBody] AddOrderCommand command)
        {
            var order = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetOrder), new { orderId = order.Id }, order);
        }
    }
}
