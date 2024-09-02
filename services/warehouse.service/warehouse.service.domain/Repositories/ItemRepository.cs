using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using warehouse.service.domain.Interfaces.Repositories;
using warehouse.service.domain.Models;

namespace warehouse.service.domain.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private List<Item> _items = [];

        public ItemRepository()
        { }

        public Item? GetItem(Guid id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Item> GetItems()
        {
            return _items;
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public void UpdateItem(Guid id, string name, decimal price, string description)
        {
            var item = GetItem(id);
            item?.Update(name, price, description);
        }

        public void DeleteItem(Guid id)
        {
            var item = GetItem(id);
            if (item != null)
                _items.Remove(item);
        }
    }
}
