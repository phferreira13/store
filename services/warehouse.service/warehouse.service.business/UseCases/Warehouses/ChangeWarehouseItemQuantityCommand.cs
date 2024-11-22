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
    public class ChangeWarehouseItemQuantityCommand : IRequest<Warehouse>
    {
        private int _warehouseId;
        public void SetWarehouseId(int warehouseId) => _warehouseId = warehouseId;
        public int ItemId { get; set; }
        public int Quantity { get; set; }

        internal class Handler(IWarehouseRepository warehouseRepository, IItemRepository itemRepository) : IRequestHandler<ChangeWarehouseItemQuantityCommand, Warehouse>
        {
            public async Task<Warehouse> Handle(ChangeWarehouseItemQuantityCommand request, CancellationToken cancellationToken)
            {
                var warehouse = await warehouseRepository.GetWarehouse(request._warehouseId);
                if (warehouse == null)
                {
                    throw new ArgumentException($"Warehouse with id {request._warehouseId} not found");
                }

                var item = warehouse.GetWarehouseItem(request.ItemId);
                if (item == null)
                {
                    if (request.Quantity < 0)
                    {
                        throw new ArgumentException($"Item with id {request.ItemId} not found in warehouse with id {request._warehouseId}");
                    }
                    else
                    {
                        var itemEntity = await itemRepository.GetItem(request.ItemId) 
                            ?? throw new ArgumentException($"Item with id {request.ItemId} not found");
                        warehouse.AddItem(itemEntity.Id, request.Quantity);
                        return warehouse;
                    }
                }

                if (request.Quantity < 0)
                {
                    warehouse.DecreaseItemQuantity(request.ItemId, Math.Abs(request.Quantity));
                }
                else
                {
                    warehouse.IncreaseItemQuantity(request.ItemId, request.Quantity);
                }

                return warehouse;
            }
        }
    }
}
