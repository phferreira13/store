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
        Task<Item?> GetItem(Guid id);
        Task<IEnumerable<Item>> GetItems();
        Task AddItem(Item item);
        Task UpdateItem(Guid id, string name, decimal price, string description);
        Task DeleteItem(Guid id);
    }
}
