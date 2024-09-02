using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warehouse.service.domain.Models
{
    public class Warehouse(string name, string location)
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = name;
        public string Location { get; private set; } = location;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; private set; }
        public List<WarehouseItem> Items { get; private set; } = [];

        public class WarehouseItem(Item item, int quantity)
        {
            public Guid Id { get; private set; } = Guid.NewGuid();
            public Item Item { get; private set; } = item;
            public int Quantity { get; private set; } = quantity;
            public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
            public DateTime? UpdatedAt { get; private set; }

            public void Update(int quantity)
            {
                Quantity = quantity;
                UpdatedAt = DateTime.UtcNow;
            }
        }

        public void Update(string name, string location)
        {
            Name = name;
            Location = location;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddItem(Item item, int quantity)
        {
            Items.Add(new WarehouseItem(item, quantity));
        }

        public void IncreaseItemQuantity(Guid itemId, int quantity = 1)
        {
            if (quantity < 1)
            {
                throw new ArgumentException("Quantity must be greater than 0");
            }

            var item = GetWarehouseItem(itemId);
            item?.Update(item.Quantity + quantity);
        }

        public void DecreaseItemQuantity(Guid itemId, int quantity = 1)
        {
            if (quantity < 1)
            {
                throw new ArgumentException("Quantity must be greater than 0");
            }

            var item = GetWarehouseItem(itemId);
            item?.Update(item.Quantity - quantity);
        }

        public WarehouseItem? GetWarehouseItem(Guid itemId)
        {
            return Items.FirstOrDefault(i => i.Item.Id == itemId);
        }
    }
}
