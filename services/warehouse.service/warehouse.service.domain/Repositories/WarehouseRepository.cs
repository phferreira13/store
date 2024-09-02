using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using warehouse.service.domain.Interfaces.Repositories;
using warehouse.service.domain.Models;

namespace warehouse.service.domain.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private List<Warehouse> _warehouses = [];

        public WarehouseRepository()
        { }

        public Warehouse? GetWarehouse(Guid id)
        {
            return _warehouses.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Warehouse> GetWarehouses()
        {
            return _warehouses;
        }

        public void AddWarehouse(Warehouse warehouse)
        {
            _warehouses.Add(warehouse);
        }

        public void UpdateWarehouse(Guid id, string name, string location)
        {
            var warehouse = GetWarehouse(id);
            warehouse?.Update(name, location);
        }

        public void AddItem(Guid warehouseId, Item item, int quantity)
        {
            var warehouse = GetWarehouse(warehouseId);
            warehouse?.AddItem(item, quantity);
        }

        public void IncreaseItemQuantity(Guid warehouseId, Guid itemId, int quantity = 1)
        {
            var warehouse = GetWarehouse(warehouseId);
            warehouse?.IncreaseItemQuantity(itemId, quantity);
        }

        public void DecreaseItemQuantity(Guid warehouseId, Guid itemId, int quantity = 1)
        {
            var warehouse = GetWarehouse(warehouseId);
            warehouse?.DecreaseItemQuantity(itemId, quantity);
        }

        public void DeleteWarehouse(Guid id)
        {
            var warehouse = GetWarehouse(id);
            if (warehouse != null)
                _warehouses.Remove(warehouse);
        }
    }
}
