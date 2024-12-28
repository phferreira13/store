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

    [TestMethod]
    [ClearDataBase]
    public async Task GetItem_ShouldReturnItem()
    {
        // Arrange
        var item = ItemFactory.CreateItem();
        await _itemRepository.AddItem(item);
        // Act
        var result = await _itemRepository.GetItem(item.Id);
        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(item.Id, result?.Id);
    }

    [TestMethod]
    [ClearDataBase]
    public async Task GetItems_ShouldReturnAllItems()
    {
        // Arrange
        var items = ItemFactory.CreateItems(5).ToList();
        foreach (var item in items)
        {
            await _itemRepository.AddItem(item);
        }
        // Act
        var result = await _itemRepository.GetItems();
        // Assert
        Assert.AreEqual(items.Count, result.Count());
    }

    [TestMethod]
    [ClearDataBase]
    public async Task UpdateItem_ShouldUpdateItem()
    {
        // Arrange
        var item = ItemFactory.CreateItem();
        await _itemRepository.AddItem(item);
        var newName = "Updated Name";
        var newPrice = 99.99m;
        var newDescription = "Updated Description";
        // Act
        await _itemRepository.UpdateItem(item.Id, newName, newPrice, newDescription);
        var updatedItem = await _itemRepository.GetItem(item.Id);
        // Assert
        Assert.IsNotNull(updatedItem);
        Assert.AreEqual(newName, updatedItem?.Name);
        Assert.AreEqual(newPrice, updatedItem?.Price);
        Assert.AreEqual(newDescription, updatedItem?.Description);
    }

    [TestMethod]
    [ClearDataBase]
    public async Task DeleteItem_ShouldDeleteItem()
    {
        // Arrange
        var item = ItemFactory.CreateItem();
        await _itemRepository.AddItem(item);
        // Act
        await _itemRepository.DeleteItem(item.Id);
        var result = await _itemRepository.GetItem(item.Id);
        // Assert
        Assert.IsNull(result);
    }
}
