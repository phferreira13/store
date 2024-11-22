using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using warehouse.service.domain.Interfaces.Repositories;
using warehouse.service.domain.Models;
using warehouse.service.entityframework.Context;

namespace warehouse.service.entityframewor.Repositories;

public class WarehouseRepository : IWarehouseRepository
{
    private readonly WarehouseContext _context;

    public WarehouseRepository(WarehouseContext context)
    {
        _context = context;
    }

    public Warehouse? GetWarehouse(Guid id)
    {
        return _context.Warehouses.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<Warehouse> GetWarehouses()
    {
        return _context.Warehouses.ToList();
    }

    public void AddWarehouse(Warehouse warehouse)
    {
        _context.Warehouses.Add(warehouse);
        _context.SaveChanges();
    }

    public void UpdateWarehouse(Guid id, string name, string location)
    {
        var warehouse = GetWarehouse(id);
        if (warehouse != null)
        {
            warehouse.Update(name, location);
            _context.SaveChanges();
        }
    }

    public void AddItem(Guid warehouseId, Item item, int quantity)
    {
        var warehouse = GetWarehouse(warehouseId);
        if (warehouse != null)
        {
            warehouse.AddItem(item, quantity);
            _context.SaveChanges();
        }
    }

    public void IncreaseItemQuantity(Guid warehouseId, Guid itemId, int quantity = 1)
    {
        var warehouse = GetWarehouse(warehouseId);
        if (warehouse != null)
        {
            warehouse.IncreaseItemQuantity(itemId, quantity);
            _context.SaveChanges();
        }
    }

    public void DecreaseItemQuantity(Guid warehouseId, Guid itemId, int quantity = 1)
    {
        var warehouse = GetWarehouse(warehouseId);
        if (warehouse != null)
        {
            warehouse.DecreaseItemQuantity(itemId, quantity);
            _context.SaveChanges();
        }
    }

    public void DeleteWarehouse(Guid id)
    {
        var warehouse = GetWarehouse(id);
        if (warehouse != null)
        {
            _context.Warehouses.Remove(warehouse);
            _context.SaveChanges();
        }
    }
}
