using Microsoft.EntityFrameworkCore;
using order.service.domain.Interfaces.Repositories;
using order.service.domain.Models;
using order.service.entityframework.Context;

namespace order.service.entityframework.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;

        public OrderRepository(OrderContext context)
        {
            _context = context;
        }

        public Order? GetById(Guid id)
        {
            return _context.Orders.Include(o => o.ItemList.Items).ThenInclude(i => i.Item)
                                  .Include(o => o.StatusHistory.History)
                                  .FirstOrDefault(o => o.Id == id);
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }
    }
}
