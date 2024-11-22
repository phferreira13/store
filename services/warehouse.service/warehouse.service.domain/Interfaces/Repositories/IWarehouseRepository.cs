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
        Task<Warehouse?> GetWarehouse(int id);
        Task<IEnumerable<Warehouse>> GetWarehouses();
        Task AddWarehouse(Warehouse warehouse);
        Task UpdateWarehouse(int id, string name, string location);
        Task AddItem(int warehouseId, Item item, int quantity);
        Task IncreaseItemQuantity(int warehouseId, int itemId, int quantity = 1);
        Task DecreaseItemQuantity(int warehouseId, int itemId, int quantity = 1);
        Task DeleteWarehouse(int id);
        Task UpdateWarehouse(Warehouse warehouse);
    }
}
