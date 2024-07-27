using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order.service.domain.Models
{
    public class Item(string name, decimal price, string description)
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = name;
        public decimal Price { get; private set; } = price;
        public string Description { get; private set; } = description;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    }
}
