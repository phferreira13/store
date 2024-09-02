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
        Warehouse? GetWarehouse(Guid id);
        IEnumerable<Warehouse> GetWarehouses();
        void AddWarehouse(Warehouse warehouse);
        void UpdateWarehouse(Guid id, string name, string location);
        void AddItem(Guid warehouseId, Item item, int quantity);
        void IncreaseItemQuantity(Guid warehouseId, Guid itemId, int quantity = 1);
        void DecreaseItemQuantity(Guid warehouseId, Guid itemId, int quantity = 1);
        void DeleteWarehouse(Guid id);
    }
}
