using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using warehouse.service.domain.Models;

namespace warehouse.service.domain.Interfaces.Repositories
{
    public interface IItemRepository
    {
        Item? GetItem(Guid id);
        IEnumerable<Item> GetItems();
        void AddItem(Item item);
        void UpdateItem(Guid id, string name, decimal price, string description);
        void DeleteItem(Guid id);
    }
}
