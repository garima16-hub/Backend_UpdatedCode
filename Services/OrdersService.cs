using System.Collections.Generic;
using System.Linq;
using _3DModels.Models;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;

namespace _3DModels.Services
{
    public class OrdersService
    {
        private readonly ModelDbContext _context;

        public OrdersService(ModelDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Orders> GetAllOrders()
        {
            return _context.Orders .ToList();
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

        public void UpdateOrder(int id, Orders order)
        {
            if (id != order.order_id)
            {
                throw new ArgumentException("Invalid Order ID.");
            }

            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                throw new NotFoundException("Order not found.");
            }

            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }
}
