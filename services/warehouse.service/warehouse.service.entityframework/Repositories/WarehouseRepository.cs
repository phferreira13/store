using Microsoft.EntityFrameworkCore;
using warehouse.service.domain.Interfaces.Repositories;
using warehouse.service.domain.Models;
using warehouse.service.entityframework.Context;

namespace warehouse.service.entityframework.Repositories;

public class WarehouseRepository : IWarehouseRepository
{
    private readonly WarehouseContext _context;

    public WarehouseRepository(WarehouseContext context)
    {
        _context = context;
    }

    public async Task<Warehouse?> GetWarehouse(int id)
    {
        return await _context.Warehouses
            .Include(x => x.Items)
            .ThenInclude(x => x.Item)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Warehouse>> GetWarehouses()
    {
        return await _context.Warehouses
            .Include(x => x.Items)
            .ThenInclude(x => x.Item)
            .ToListAsync();
    }

    public async Task AddWarehouse(Warehouse warehouse)
    {
        try
        {
            _context.Warehouses.Add(warehouse);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public async Task UpdateWarehouse(int id, string name, string location)
    {
        var warehouse = await GetWarehouse(id);
        if (warehouse != null)
        {
            warehouse.Update(name, location);
            await _context.SaveChangesAsync();
        }
    }

    public async Task AddItem(int warehouseId, Item item, int quantity)
    {
        var warehouse = await GetWarehouse(warehouseId);
        if (warehouse != null)
        {
            warehouse.AddItem(item.Id, quantity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task IncreaseItemQuantity(int warehouseId, int itemId, int quantity = 1)
    {
        var warehouse = await GetWarehouse(warehouseId);
        if (warehouse != null)
        {
            warehouse.IncreaseItemQuantity(itemId, quantity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DecreaseItemQuantity(int warehouseId, int itemId, int quantity = 1)
    {
        var warehouse = await GetWarehouse(warehouseId);
        if (warehouse != null)
        {
            warehouse.DecreaseItemQuantity(itemId, quantity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteWarehouse(int id)
    {
        var warehouse = await GetWarehouse(id);
        if (warehouse != null)
        {
            _context.Warehouses.Remove(warehouse);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateWarehouse(Warehouse warehouse)
    {
        _context.Warehouses.Update(warehouse);
        await _context.SaveChangesAsync();
    }
}
