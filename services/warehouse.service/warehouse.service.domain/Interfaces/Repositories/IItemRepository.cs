using warehouse.service.domain.Models;

namespace warehouse.service.domain.Interfaces.Repositories
{
    public interface IItemRepository
    {
        Task<Item?> GetItem(int id);
        Task<IEnumerable<Item>> GetItems();
        Task AddItem(Item item);
        Task UpdateItem(int id, string name, decimal price, string description);
        Task DeleteItem(int id);
        Task UpdateItem(Item item);
    }
}
