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
    public class GetWarehousesQuery : IRequest<IEnumerable<Warehouse>>
    {
        internal class Handler(IWarehouseRepository warehouseRepository) : IRequestHandler<GetWarehousesQuery, IEnumerable<Warehouse>>
        {
            public Task<IEnumerable<Warehouse>> Handle(GetWarehousesQuery request, CancellationToken cancellationToken)
            {
                var warehouses = warehouseRepository.GetWarehouses();
                return Task.FromResult(warehouses);
            }
        }
    }
}
