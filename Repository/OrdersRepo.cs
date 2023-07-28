using System.Collections.Generic;
using System.Linq;
using _3DModels.Models;
using Microsoft.EntityFrameworkCore;

namespace _3DModels.Repositories
{
    public class OrdersRepository
    {
        private readonly ModelDbContext _context;

        public OrdersRepository(ModelDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Orders> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        public Orders GetOrderById(int id)
        {
            return _context.Orders.Find(id);
        }

        public void AddOrder(Orders order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void UpdateOrder(Orders order)
        {
            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteOrder(Orders order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }
}
