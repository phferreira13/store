using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    public Item? GetItem(Guid id)
    {
        return _context.Items.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<Item> GetItems()
    {
        return _context.Items.ToList();
    }

    public void AddItem(Item item)
    {
        _context.Items.Add(item);
        _context.SaveChanges();
    }

    public void UpdateItem(Guid id, string name, decimal price, string description)
    {
        var item = GetItem(id);
        if (item != null)
        {
            item.Update(name, price, description);
            _context.SaveChanges();
        }
    }

    public void DeleteItem(Guid id)
    {
        var item = GetItem(id);
        if (item != null)
        {
            _context.Items.Remove(item);
            _context.SaveChanges();
        }
    }
}
