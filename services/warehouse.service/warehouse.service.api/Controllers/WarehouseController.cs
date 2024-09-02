using MediatR;
using Microsoft.AspNetCore.Mvc;
using warehouse.service.business.UseCases.Warehouses;
using warehouse.service.domain.Models;

namespace warehouse.service.api.Controllers
{
    [ApiController]
    [Route("api/warehouses")]
    public class WarehouseController(IMediator mediator) : ControllerBase
    {

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Warehouse>), 200)]
        public async Task<IActionResult> GetWarehouses()
        {
            var warehouses = await mediator.Send(new GetWarehousesQuery());
            return Ok(warehouses);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Warehouse), 200)]
        public async Task<IActionResult> CreateWarehouse([FromBody] CreateWarehouseCommand command)
        {
            var warehouse = await mediator.Send(command);
            return Ok(warehouse);
        }

        [HttpPost("{id}/items")]
        [ProducesResponseType(typeof(Warehouse), 200)]
        public async Task<IActionResult> ChangeWarehouseItemQuantity(Guid id, [FromBody] ChangeWarehouseItemQuantityCommand command)
        {
            command.SetWarehouseId(id);
            var warehouse = await mediator.Send(command);
            return Ok(warehouse);
        }
    }
}
