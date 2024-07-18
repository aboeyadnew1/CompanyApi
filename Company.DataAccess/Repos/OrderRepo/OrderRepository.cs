using Company.DataAccess.Data;
using Company.DataAccess.Models;
using Company.DataAccess.Repos.MainRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DataAccess.Repos.OrderRepo
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Order> AddAsync(Order entity)
        {
            var customerExist = await _context.Customers.AnyAsync(x => x.Id == entity.CustomerId);

            if (!customerExist)
            {
                throw new Exception("Customer does not exist. Please add the customer first to complete your order.");
            }

            await _context.Orders.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;

        }
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders.Include(e=>e.Customer).ToListAsync();
        }
        public async Task UpdateAsync(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders.Include(e => e.Customer).FirstOrDefaultAsync(e=> e.Id ==id);
        }
        public async Task DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<int> GetOrderCountAsync()
        {
            return await _context.Orders.Include(e=> e.Customer).CountAsync();
        }
        public async Task<bool> CustomerExistsAsync(int customerId)
        {
            return await _context.Customers.AnyAsync(c => c.Id == customerId);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();

        }
    }
}
