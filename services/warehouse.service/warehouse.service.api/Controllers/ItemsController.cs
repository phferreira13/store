using MediatR;
using Microsoft.AspNetCore.Mvc;
using warehouse.service.business.UseCases.Items;
using warehouse.service.domain.Models;

namespace warehouse.service.api.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Item>), 200)]
        public async Task<IActionResult> GetItems()
        {
            var items = await _mediator.Send(new GetItemsQuery());
            return Ok(items);
        }
    }
}
