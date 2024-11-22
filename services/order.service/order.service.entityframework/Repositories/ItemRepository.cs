using Microsoft.EntityFrameworkCore;
using order.service.domain.Dtos;
using order.service.domain.Interfaces.Repositories;
using order.service.entityframework.Context;

namespace order.service.entityframework.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly OrderContext _context;

        public ItemRepository(OrderContext context)
        {
            _context = context;
        }

        public async Task<ItemDto?> GetByIdAsync(Guid itemId)
        {
            var item = await _context.Items.FindAsync(itemId);
            return item != null ? new ItemDto(item.Id, item.Name, item.Price, item.Description) : null;
        }

        public void Add(ItemDto item)
        {
            var entity = new Item
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                Description = item.Description
            };
            _context.Items.Add(entity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<ItemDto>> GetAll()
        {
            var items = await _context.Items.ToListAsync();
            return items.Select(item => new ItemDto(item.Id, item.Name, item.Price, item.Description));
        }
    }
}
