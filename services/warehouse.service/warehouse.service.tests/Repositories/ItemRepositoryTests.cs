using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using warehouse.service.entityframework.Repositories;
using warehouse.service.entityframework.Context;
using warehouse.service.tests.shared.Factories;

namespace warehouse.service.tests.Repositories;

[TestClass]
public class ItemRepositoryTests : RepositoryInitializer
{
    private readonly ItemRepository _itemRepository;

    public ItemRepositoryTests()
    {
        _itemRepository = new ItemRepository(_context);
    }

    [TestMethod]
    [ClearDataBase]
    public async Task AddItem_ShouldAddItem()
    {
        // Arrange
        var item = ItemFactory.CreateItem();
        // Act
        await _itemRepository.AddItem(item);
        // Assert
        var result = await _context.Items.FirstOrDefaultAsync(x => x.Id == item.Id);
        Assert.IsNotNull(result);
    }
}
