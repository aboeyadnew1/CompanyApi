using AutoMapper;
using Company.Business.Dto.Order;
using Company.DataAccess.Models;
using Company.DataAccess.Repos.OrderRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Business.Service.OrderService
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderServices(IOrderRepository OrderRepository, IMapper mapper)
        {
            _orderRepository = OrderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReadOrderDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();

            // تحويل الكائنات Order إلى OrderDto مع الحفاظ على العلاقة مع العميل
            return orders.Select(o => new ReadOrderDto
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                CustomerId = o.CustomerId,
                TotalAmount = o.TotalAmount,
                OrderStatus = o.OrderStatus,
                Name = o.Customer?.Name // تخيل أن o.Customer هو العلاقة بين الطلب والعميل
            }).ToList();

        }

        public async Task<ReadOrderDto> GetOrderByIdAsync(int id)
        {

            var Order = await _orderRepository.GetByIdAsync(id);
            if (Order == null)
            {
                throw new Exception("Wrong Id ..!");
            }
            else
            {
                return new ReadOrderDto
                {
                    Id = Order.Id,
                    OrderDate = Order.OrderDate,
                    CustomerId = Order.CustomerId,
                    TotalAmount = Order.TotalAmount,
                    OrderStatus = Order.OrderStatus,
                    Name = Order.Customer?.Name // تخيل أن o.Customer هو العلاقة بين الطلب والعميل
                };
            }
        }

        public async Task Add(AddOrderDto OrderDto)
        {
            var Order = _mapper.Map<Order>(OrderDto);
            await _orderRepository.AddAsync(Order);
            await _orderRepository.SaveAsync();
        }



        public async Task DeleteOrderAsync(int id)
        {
            await _orderRepository.DeleteAsync(id);
            await _orderRepository.SaveAsync();
        }

        //public async Task UpdateOrderAsync(int id, ReadOrderDto OrderDto)
        //{
        //    var Order = await _orderRepository.GetByIdAsync(id);
        //    if (Order == null) throw new KeyNotFoundException("Order not found");

        //    _mapper.Map(OrderDto, Order);
        //    await _orderRepository.UpdateAsync(Order);
        //    await _orderRepository.SaveAsync();
        //}
        public async Task UpdateOrderAsync(int id, ReadOrderDto OrderDto)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(id);

            if (existingOrder == null)
            {
                throw new ArgumentException($"Order with id {id} not found");
            }

            // تحديث العميل باستخدام AutoMapper
            _mapper.Map(OrderDto, existingOrder);

            // حفظ التغييرات في قاعدة البيانات
            await _orderRepository.UpdateAsync(existingOrder);
        }


    }
}
