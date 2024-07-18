using Company.Business.Dto.Order;
using Company.Business.Dto.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Business.Service.OrderService
{
    public interface IOrderServices
    {
        Task<IEnumerable<ReadOrderDto>> GetAllOrdersAsync();
        Task<ReadOrderDto> GetOrderByIdAsync(int id);
        Task Add(AddOrderDto orderDto);
        //  Task UpdateOrderAsync(int id, ReadOrderDto OrderDto);
        Task DeleteOrderAsync(int id);
        Task UpdateOrderAsync(int id, ReadOrderDto orderDto);

    }
}
