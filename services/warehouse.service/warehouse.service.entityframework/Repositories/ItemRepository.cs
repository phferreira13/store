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

public class ItemRepository : IItemRepository
{
    private readonly WarehouseContext _context;

    public ItemRepository(WarehouseContext context)
    {
        _context = context;
    }

    public async Task<Item?> GetItem(Guid id)
    {
        return await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Item>> GetItems()
    {
        return await _context.Items.ToListAsync();
    }

    public async Task AddItem(Item item)
    {
        _context.Items.Add(item);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateItem(Guid id, string name, decimal price, string description)
    {
        var item = await GetItem(id);
        if (item != null)
        {
            item.Update(name, price, description);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteItem(Guid id)
    {
        var item = await GetItem(id);
        if (item != null)
        {
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
