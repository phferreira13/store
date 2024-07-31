using order.service.domain.Interfaces.Repositories;
using order.service.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order.service.domain.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private List<Item> _items = new();

        public void Add(Item item)
        {
            _items.Add(item);
        }

        public Item? GetById(Guid itemId)
        {
            return _items.FirstOrDefault(i => i.Id == itemId);
        }

        public IEnumerable<Item> GetAll()
        {
            return _items;
        }
    }
}
