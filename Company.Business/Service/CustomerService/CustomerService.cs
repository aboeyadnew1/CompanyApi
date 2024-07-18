using AutoMapper;
using Company.Business.Dto.Customer;
using Company.DataAccess.Models;
using Company.DataAccess.Repos.CustomerRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Business.Service.CustomerService
{
    public  class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReadCustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ReadCustomerDto>>(customers);
        }

        public async Task<ReadCustomerDto> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            return _mapper.Map<ReadCustomerDto>(customer);
        }

        public async Task Add(AddCustomerDto customerDto)
        {
            var existingCustomer = await _customerRepository.Customers
           .AnyAsync(c => c.Email == customerDto.Email);
            if (existingCustomer)
            {
                throw new Exception("Customer already exists.");
            }
            var customer = _mapper.Map<Customer>(customerDto);
            await _customerRepository.AddAsync(customer);
            await _customerRepository.SaveAsync();
        }

     

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
            await _customerRepository.SaveAsync();
        }

        //public async Task UpdateCustomerAsync(int id, ReadCustomerDto customerDto)
        //{
        //    var customer = await _customerRepository.GetByIdAsync(id);
        //    if (customer == null) throw new KeyNotFoundException("Customer not found");

        //    _mapper.Map(customerDto, customer);
        //    await _customerRepository.UpdateAsync(customer);
        //    await _customerRepository.SaveAsync();
        //}
        public async Task UpdateCustomerAsync(int id, ReadCustomerDto customerDto)
        {
            var existingCustomer = await _customerRepository.GetByIdAsync(id);

            if (existingCustomer == null)
            {
                throw new ArgumentException($"Customer with id {id} not found");
            }

            // تحديث العميل باستخدام AutoMapper
            _mapper.Map(customerDto, existingCustomer);

            // حفظ التغييرات في قاعدة البيانات
            await _customerRepository.UpdateAsync(existingCustomer);
        }


    }
}
