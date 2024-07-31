using order.service.domain.Interfaces.Repositories;

namespace order.service.api.Mock
{
    public class MockService(IItemRepository itemRepository)
    {
        private readonly IItemRepository _itemRepository = itemRepository;

        public void SeedItems()
        {
            var items = ItemFactory.CreateItems(10);
            foreach (var item in items)
            {
                _itemRepository.Add(item);
            }
        }
    }
}
