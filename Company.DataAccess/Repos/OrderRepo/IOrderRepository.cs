using Company.DataAccess.Models;
using Company.DataAccess.Repos.MainRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DataAccess.Repos.OrderRepo
{
    public interface IOrderRepository : IRepository<Order>
    {

        Task<int> GetOrderCountAsync();
        Task<bool> CustomerExistsAsync(int customerId);
    }
}
