using warehouse.service.domain.Interfaces.Repositories;

namespace warehouse.service.api.Mock
{
    public class MockService(IItemRepository itemRepository)
    {
        private readonly IItemRepository _itemRepository = itemRepository;

        public async Task SeedItems()
        {
            var items = ItemFactory.CreateItems(10);
            foreach (var item in items)
            {
                await _itemRepository.AddItem(item);
            }
        }
    }
}
