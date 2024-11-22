using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

    public async Task<Warehouse?> GetWarehouse(Guid id)
    {
        return await _context.Warehouses.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Warehouse>> GetWarehouses()
    {
        return await _context.Warehouses.ToListAsync();
    }

    public async Task AddWarehouse(Warehouse warehouse)
    {
        _context.Warehouses.Add(warehouse);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateWarehouse(Guid id, string name, string location)
    {
        var warehouse = await GetWarehouse(id);
        if (warehouse != null)
        {
            warehouse.Update(name, location);
            await _context.SaveChangesAsync();
        }
    }

    public async Task AddItem(Guid warehouseId, Item item, int quantity)
    {
        var warehouse = await GetWarehouse(warehouseId);
        if (warehouse != null)
        {
            warehouse.AddItem(item, quantity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task IncreaseItemQuantity(Guid warehouseId, Guid itemId, int quantity = 1)
    {
        var warehouse = await GetWarehouse(warehouseId);
        if (warehouse != null)
        {
            warehouse.IncreaseItemQuantity(itemId, quantity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DecreaseItemQuantity(Guid warehouseId, Guid itemId, int quantity = 1)
    {
        var warehouse = await GetWarehouse(warehouseId);
        if (warehouse != null)
        {
            warehouse.DecreaseItemQuantity(itemId, quantity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteWarehouse(Guid id)
    {
        var warehouse = await GetWarehouse(id);
        if (warehouse != null)
        {
            _context.Warehouses.Remove(warehouse);
            await _context.SaveChangesAsync();
        }
    }
}
