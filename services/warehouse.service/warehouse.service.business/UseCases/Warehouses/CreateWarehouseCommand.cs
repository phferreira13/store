using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using warehouse.service.domain.Interfaces.Repositories;
using warehouse.service.domain.Models;

namespace warehouse.service.business.UseCases.Warehouses
{
    public class CreateWarehouseCommand : IRequest<Warehouse>
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public List<AddWarehouseItemCommand> Items { get; set; } = [];

        public class AddWarehouseItemCommand
        {
            public int ItemId { get; set; }
            public int Quantity { get; set; }
        }

        internal class Handler(IWarehouseRepository warehouseRepository, IItemRepository itemRepository) : IRequestHandler<CreateWarehouseCommand, Warehouse>
        {
            public async Task<Warehouse> Handle(CreateWarehouseCommand request, CancellationToken cancellationToken)
            {
                var warehouse = new Warehouse(request.Name, request.Location);

                foreach (var item in request.Items)
                {
                    warehouse.AddItem(item.ItemId, item.Quantity);
                }

                await warehouseRepository.AddWarehouse(warehouse);

                return warehouse;
            }
        }
    }
}
