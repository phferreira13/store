using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using warehouse.service.domain.Models;

namespace warehouse.service.domain.Interfaces.Repositories
{
    public interface IWarehouseRepository
    {
        Task<Warehouse?> GetWarehouse(Guid id);
        Task<IEnumerable<Warehouse>> GetWarehouses();
        Task AddWarehouse(Warehouse warehouse);
        Task UpdateWarehouse(Guid id, string name, string location);
        Task AddItem(Guid warehouseId, Item item, int quantity);
        Task IncreaseItemQuantity(Guid warehouseId, Guid itemId, int quantity = 1);
        Task DecreaseItemQuantity(Guid warehouseId, Guid itemId, int quantity = 1);
        Task DeleteWarehouse(Guid id);
    }
}
