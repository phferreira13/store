using Bogus;
using warehouse.service.domain.Models;

namespace warehouse.service.api.Mock
{
    public static class ItemFactory
    {
        public static IEnumerable<Item> CreateItems(int count = 1)
        {
            var faker = new Faker<Item>(locale: "pt_BR")
                .CustomInstantiator(f => new Item(
                    name: f.Commerce.ProductName(), 
                    price: Math.Round(f.Random.Decimal(1, 1000), 2),
                    description: f.Lorem.Sentence())
                );
            return faker.Generate(count);
        }
    }
}
